using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PG.Helper
{
    public class OracleHelper
    {
        #region "ExecuteReader"
        public static IDataReader ExcuteOracleReader(string connectionString, string command, CommandType commandType, OracleParameterList parameters)
        {
            IDataReader result;
            result = ExecuteOracleReader(connectionString, command, commandType, parameters, -1);
            return result;
        }

        public static IDataReader ExecuteOracleReader(string connectionString, string command, CommandType commandType, OracleParameterList parameters, int commandTimeoutInSeconds)
        {
            IDataReader result;
            OracleConnection oracleConnection = null;
            IDataReader dataReader = null;
            try
            {
                oracleConnection = new OracleConnection(connectionString);
                oracleConnection.Open();
                dataReader = ExecuteOracleReader(oracleConnection, command, commandType, parameters, true, commandTimeoutInSeconds);
            }
            catch
            {
                if (oracleConnection != null && oracleConnection.State == ConnectionState.Open)
                {
                    oracleConnection.Close();
                }
                dataReader = null;
                throw;
            }
            result = dataReader;

            return result;
        }

        private static IDataReader ExecuteOracleReader(OracleConnection connection, string command, CommandType commandType, OracleParameterList parameters, bool AutoCloseConnectionOnReaderDispose, int commandTimeoutInSeconds)
        {
            OracleDataReader result = null;
            OracleParameter[] oracleParameterList = GetOracleParameterList(parameters);
            using (OracleCommand oracleCommand = connection.CreateCommand())
            {
                oracleCommand.CommandText = command;
                oracleCommand.CommandType = commandType;
                oracleCommand.Parameters.AddRange(oracleParameterList);
                if (commandTimeoutInSeconds != -1)
                {
                    oracleCommand.CommandTimeout = commandTimeoutInSeconds;
                }
                DateTime now = DateTime.Now;
                if (AutoCloseConnectionOnReaderDispose)
                {
                    result = oracleCommand.ExecuteReader(CommandBehavior.CloseConnection);
                }
                else
                {
                    result = oracleCommand.ExecuteReader();
                }
                TimeSpan duration = DateTime.Now.Subtract(now);
            }
            UpdateReturnedParameters(oracleParameterList, parameters);
            return result;
        }
        #endregion

        #region "ExecuteNonQuery"
        public static int ExecuteNonQuery(string connectionString, string command, CommandType commandType, OracleParameterList parameters, int commandTimeoutInSeconds)
        {
            int result;
            int num = 0;
            using (OracleConnection oracleConnection = new OracleConnection(connectionString))
            {
                oracleConnection.Open();
                num = ExecuteNonQuery(oracleConnection, command, commandType, parameters, commandTimeoutInSeconds);
                oracleConnection.Close();
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

        public static int ExecuteNonQuery(OracleConnection connection, string command, CommandType commandType, OracleParameterList parameters, int commandTimeoutInSeconds)
        {
            int result;
            int num = 0;
            OracleParameter[] sqlParameterList = GetOracleParameterList(parameters);
            using (OracleCommand oracleCommand = new OracleCommand())
            {
                oracleCommand.Connection = connection;
                oracleCommand.CommandText = command;
                oracleCommand.CommandType = commandType;
                //sqlCommand.Transaction = connection.BeginTransaction();
                if (commandTimeoutInSeconds > 0)
                {
                    oracleCommand.CommandTimeout = commandTimeoutInSeconds;
                }
                oracleCommand.Parameters.AddRange(sqlParameterList);
                DateTime now = DateTime.Now;
                num = oracleCommand.ExecuteNonQuery();

                TimeSpan duration = DateTime.Now.Subtract(now);

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

        public static OracleParameter[] GetOracleParameterList(OracleParameterList parameters)
        {
            List<OracleParameter> list = new List<OracleParameter>();
            if (parameters != null)
            {
                foreach (OracleParameterListItem current in parameters.Items)
                {
                    if (!current._OracleParameterInfoSet)
                    {
                        throw new ArgumentException("The parameter's Oracle information is not set. Use the ParameterList.Add() overload to set Oracle parameter information when creating the Parameters list.");
                    }
                    OracleParameter oracleParameter = new OracleParameter();
                    oracleParameter.Direction = current.OracleParameterDirection;
                    oracleParameter.ParameterName = current.Key;
                    oracleParameter.OracleDbType = current.OracleDbType;
                    if (oracleParameter.Direction == ParameterDirection.Output)
                    {
                        OracleDbType oracleDbType = oracleParameter.OracleDbType;
                        switch (oracleDbType)
                        {
                            case OracleDbType.NChar:
                            case OracleDbType.Long:
                            case OracleDbType.NVarchar2:
                                goto IL_C6;
                            default:
                                switch (oracleDbType)
                                {
                                    case OracleDbType.Long:
                                    case OracleDbType.Raw:
                                    case OracleDbType.Varchar2:
                                        goto IL_C6;
                                }
                                break;
                        }
                        goto IL_D5;
                    IL_C6:
                        oracleParameter.Size = 2147483647;
                    }
                IL_D5:
                    oracleParameter.Value = ConvertValueIn(current.OracleDbType, current.Value);
                    list.Add(oracleParameter);
                }
            }
            return list.ToArray();
        }

        private static void UpdateReturnedParameters(OracleParameter[] oracleParameterList, OracleParameterList parameters)
        {
            for (int i = 0; i < oracleParameterList.Length; i++)
            {
                OracleParameter oracleParameter = oracleParameterList[i];
                switch (oracleParameter.Direction)
                {
                    case ParameterDirection.Output:
                    case ParameterDirection.InputOutput:
                    case ParameterDirection.ReturnValue:
                        parameters.Set(oracleParameter.ParameterName, ConvertValueOut(oracleParameter.OracleDbType, oracleParameter.Value));
                        break;
                }
            }
        }

        private static object ConvertValueOut(OracleDbType ValueType, object Value)
        {
            object result;
            if (Value == DBNull.Value)
            {
                result = null;
            }
            else if (ValueType != OracleDbType.Char)
            {
                result = Value;
            }
            else
            {
                result = Convert.ToBoolean(Value);
            }
            return result;
        }

        private static object ConvertValueIn(OracleDbType ValueType, object Value)
        {
            object result;
            if (Value == null)
            {
                result = DBNull.Value;
            }
            else if (ValueType != OracleDbType.Char)
            {
                result = Value;
            }
            else
            {
                result = ConvertValueIn(typeof(bool), Value);
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
