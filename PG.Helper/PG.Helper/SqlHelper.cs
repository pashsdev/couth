using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace PG.Helper
{
    public class SqlHelper
    {
        #region "ExecuteDataSet"
        public static DataSet ExecuteDataSet(string connectionString, string command, CommandType commandType, ParameterList parameters)
        {
            DataSet result;
            DataSet dataSet = new DataSet();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                dataSet = SqlHelper.ExecuteDataSet(sqlConnection, command, commandType, parameters);
                sqlConnection.Close();
            }
            result = dataSet;

            return result;
        }

        public static DataSet ExecuteDataSet(SqlConnection connection, string command, CommandType commandType, ParameterList parameters)
        {
            DataSet result;
            DataSet dataSet = new DataSet();
            SqlParameter[] sqlParameterList = SqlHelper.GetSqlParameterList(parameters);
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = command;
                sqlCommand.CommandType = commandType;
                sqlCommand.Parameters.AddRange(sqlParameterList);
                DateTime now = DateTime.Now;
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    do
                    {
                        DataTable dataTable = new DataTable();
                        while (sqlDataReader.Read())
                        {
                            if (dataTable.Columns.Count == 0)
                            {
                                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                                {
                                    Type fieldType = sqlDataReader.GetFieldType(i);
                                    object value = sqlDataReader.GetProviderSpecificFieldType(i);
                                    DataColumn dataColumn = new DataColumn();
                                    dataColumn.ColumnName = sqlDataReader.GetName(i);
                                    dataColumn.DataType = fieldType;
                                    dataTable.Columns.Add(dataColumn);
                                }
                            }
                            DataRow dataRow = dataTable.NewRow();
                            for (int i = 0; i < sqlDataReader.FieldCount; i++)
                            {
                                object value = sqlDataReader.GetValue(i);
                                dataRow[i] = value;
                            }
                            dataTable.Rows.Add(dataRow);
                        }
                        dataSet.Tables.Add(dataTable);
                    }
                    while (sqlDataReader.NextResult());
                }
                SqlHelper.UpdateReturnedParameters(sqlParameterList, parameters);
            }
            result = dataSet;
            return result;
        }
        #endregion

        #region "ExecuteNonQuery"
        public static int ExecuteNonQuery(string connectionString, string command, CommandType commandType, ParameterList parameters)
        {
            return SqlHelper.ExecuteNonQuery(connectionString, command, commandType, parameters, 0);
        }

        public static int ExecuteNonQuery(string connectionString, string command, CommandType commandType, ParameterList parameters, int commandTimeoutInSeconds)
        {
            int result;
            int num = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                num = SqlHelper.ExecuteNonQuery(sqlConnection, command, commandType, parameters, commandTimeoutInSeconds);
                sqlConnection.Close();
            }
            if (commandType == CommandType.Text)
            {
                result = num;
            }
            else
            {
                result = -1;
            }
            return result;
        }

        public static int ExecuteNonQuery(SqlConnection connection, string command, CommandType commandType, ParameterList parameters)
        {
            return SqlHelper.ExecuteNonQuery(connection, command, commandType, parameters, 0);
        }

        public static int ExecuteNonQuery(SqlConnection connection, string command, CommandType commandType, ParameterList parameters, int commandTimeoutInSeconds)
        {
            int result;
            int num = 0;
            SqlParameter[] sqlParameterList = SqlHelper.GetSqlParameterList(parameters);
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = command;
                sqlCommand.CommandType = commandType;
                //sqlCommand.Transaction = connection.BeginTransaction();
                if (commandTimeoutInSeconds > 0)
                {
                    sqlCommand.CommandTimeout = commandTimeoutInSeconds;
                }
                sqlCommand.Parameters.AddRange(sqlParameterList);
                DateTime now = DateTime.Now;
                num = sqlCommand.ExecuteNonQuery();

                TimeSpan duration = DateTime.Now.Subtract(now);

                SqlHelper.UpdateReturnedParameters(sqlParameterList, parameters);
                if (commandType == CommandType.Text)
                {
                    result = num;
                }
                else
                {
                    result = -1;
                }
            }
            return result;
        }
        #endregion

        #region "ExecuteReader"
        public static IDataReader ExecuteReader(string connectionString, string command, CommandType commandType, ParameterList parameters)
        {
            IDataReader result;
            result = ExecuteReader(connectionString, command, commandType, parameters, -1);
            return result;
        }

        public static IDataReader ExecuteReader(string connectionString, string command, CommandType commandType, ParameterList parameters, int commandTimeoutInSeconds)
        {
            IDataReader result;
            SqlConnection sqlConnection = null;
            IDataReader dataReader = null;
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                dataReader = SqlHelper.ExecuteReader(sqlConnection, command, commandType, parameters, true, commandTimeoutInSeconds);
            }
            catch
            {
                if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                dataReader = null;
                throw;
            }
            result = dataReader;

            return result;
        }

        private static IDataReader ExecuteReader(SqlConnection connection, string command, CommandType commandType, ParameterList parameters, bool AutoCloseConnectionOnReaderDispose, int commandTimeoutInSeconds)
        {
            SqlDataReader result = null;
            SqlParameter[] sqlParameterList = SqlHelper.GetSqlParameterList(parameters);
            using (SqlCommand sqlCommand = connection.CreateCommand())
            {
                sqlCommand.CommandText = command;
                sqlCommand.CommandType = commandType;
                sqlCommand.Parameters.AddRange(sqlParameterList);
                if (commandTimeoutInSeconds != -1)
                {
                    sqlCommand.CommandTimeout = commandTimeoutInSeconds;
                }
                DateTime now = DateTime.Now;
                if (AutoCloseConnectionOnReaderDispose)
                {
                    result = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                }
                else
                {
                    result = sqlCommand.ExecuteReader();
                }
                TimeSpan duration = DateTime.Now.Subtract(now);
            }
            SqlHelper.UpdateReturnedParameters(sqlParameterList, parameters);
            return result;
        }
        #endregion

        public static SqlParameter[] GetSqlParameterList(ParameterList parameters)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            if (parameters != null)
            {
                foreach (ParameterListItem current in parameters.Items)
                {
                    if (!current._SqlParameterInfoSet)
                    {
                        throw new ArgumentException("The parameter's SQL information is not set. Use the ParameterList.Add() overload to set SQL parameter information when creating the Parameters list.");
                    }
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter.Direction = current.SqlParameterDirection;
                    sqlParameter.ParameterName = current.Key;
                    sqlParameter.SqlDbType = current.SqlDbType;
                    if (sqlParameter.Direction == ParameterDirection.Output)
                    {
                        SqlDbType sqlDbType = sqlParameter.SqlDbType;
                        switch (sqlDbType)
                        {
                            case SqlDbType.NChar:
                            case SqlDbType.NText:
                            case SqlDbType.NVarChar:
                                goto IL_C6;
                            default:
                                switch (sqlDbType)
                                {
                                    case SqlDbType.Text:
                                    case SqlDbType.VarBinary:
                                    case SqlDbType.VarChar:
                                        goto IL_C6;
                                }
                                break;
                        }
                        goto IL_D5;
                    IL_C6:
                        sqlParameter.Size = 2147483647;
                    }
                IL_D5:
                    sqlParameter.Value = SqlHelper.ConvertValueIn(current.SqlDbType, current.Value);
                    list.Add(sqlParameter);
                }
            }
            return list.ToArray();
        }

        private static void UpdateReturnedParameters(SqlParameter[] sqlParameterList, ParameterList parameters)
        {
            for (int i = 0; i < sqlParameterList.Length; i++)
            {
                SqlParameter sqlParameter = sqlParameterList[i];
                switch (sqlParameter.Direction)
                {
                    case ParameterDirection.Output:
                    case ParameterDirection.InputOutput:
                    case ParameterDirection.ReturnValue:
                        parameters.Set(sqlParameter.ParameterName, SqlHelper.ConvertValueOut(sqlParameter.SqlDbType, sqlParameter.Value));
                        break;
                }
            }
        }

        private static object ConvertValueOut(SqlDbType ValueType, object Value)
        {
            object result;
            if (Value == DBNull.Value)
            {
                result = null;
            }
            else if (ValueType != SqlDbType.Bit)
            {
                result = Value;
            }
            else
            {
                result = Convert.ToBoolean(Value);
            }
            return result;
        }

        private static object ConvertValueIn(SqlDbType ValueType, object Value)
        {
            object result;
            if (Value == null)
            {
                result = DBNull.Value;
            }
            else if (ValueType != SqlDbType.Bit)
            {
                result = Value;
            }
            else
            {
                result = SqlHelper.ConvertValueIn(typeof(bool), Value);
            }
            return result;
        }

        private static object ConvertValueIn(Type ValueType, object Value)
        {
            object result;
            if (Value == null)
            {
                result = DBNull.Value;
            }
            else if (ValueType == typeof(bool))
            {
                if (Value is string)
                {
                    string a = (string)Value;
                    if (a == "0")
                    {
                        result = 0;
                        return result;
                    }
                    if (a == "1")
                    {
                        result = 1;
                        return result;
                    }
                }
                result = (Convert.ToBoolean(Value) ? 1 : 0);
            }
            else
            {
                result = Value;
            }
            return result;
        }

    }
}
