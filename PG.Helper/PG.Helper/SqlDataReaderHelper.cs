using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace PG.Helper
{
    public class SqlDataReaderHelper
    {
        private const int READ_BUFFER_SIZE = 65536;

        private IDataReader _Reader;

        /// <summary>
        /// Creates a new instance of SqlDataReaderHelper.
        /// </summary>
        /// <param name="dataReader">
        /// The data reader that will be read from.
        /// </param>
        public SqlDataReaderHelper(IDataReader dataReader)
        {
            this._Reader = dataReader;
        }

        /// <summary>
        /// Creates a new instance of SqlDataReaderHelper.
        /// </summary>
        /// <param name="record">
        /// The data record that will be read from.
        /// </param>
        public SqlDataReaderHelper(IDataRecord record)
        {
            this._Reader = (record as IDataReader);
        }

        /// <summary>
        /// Determines is a column exists in the current reader.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <returns>
        /// <b>true</b> if the column exists, <b>false</b> if the column does not exist.
        /// </returns>
        public bool ColumnExists(string columnName)
        {
            bool result;
            try
            {
                int ordinal = this._Reader.GetOrdinal(columnName);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Gets a value that indicates whether the columnName value is DBNull.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <returns>
        /// <b>true</b> if the columnName value is DBNull, otherwise <b>false</b>.
        /// </returns>
        public bool IsDBNull(string columnName)
        {
            int ordinal = this._Reader.GetOrdinal(columnName);
            return this._Reader.IsDBNull(ordinal);
        }

        /// <summary>
        /// Gets a value by colum name from the SQL data reader.
        /// If the column is DbNull, then default(T) will be returned.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the data to be read.
        /// </typeparam>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <returns>
        /// Data from the reader cast to the specified type &lt;T&gt;.
        /// </returns>
        public T GetValue<T>(string columnName)
        {
            int i = -1;
            try
            {
                i = this._Reader.GetOrdinal(columnName);
            }
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException)
                {
                    string message = string.Format("The column name '{0}' does not exist.", ex.Message);
                    ex = new IndexOutOfRangeException(message, ex);
                    throw ex;
                }
                throw;
            }
            T result;
            if (this._Reader.GetValue(i).GetType() == typeof(T))
            {
                result = (T)((object)this._Reader.GetValue(i));
            }
            else
            {
                try
                {
                    result = ConvertToType<T>(this._Reader.GetValue(i));
                }
                catch
                {
                    result = default(T);
                }
            }
            return result;
        }

        /// <summary>
        /// Gets a Boolean value from the specified columnName.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <returns>
        /// A Boolean value from the specified columnName.  
        /// If the column value is null, then <b>false</b> will be returned.
        /// </returns>
        public bool GetBoolean(string columnName)
        {
            return this.GetValue<bool>(columnName);
        }

        /// <summary>
        /// Gets a Byte value from the specified columnName.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <returns>
        /// A Byte value from the specified columnName.  
        /// If the column value is null, then (byte)0 will be returned.
        /// </returns>
        public byte GetByte(string columnName)
        {
            return this.GetValue<byte>(columnName);
        }

        /// <summary>
        /// Reads bytes from the specified columnName into a buffer.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <param name="dataIndex">
        /// The starting index from which data will be read (from columnName).
        /// </param>
        /// <param name="buffer">
        /// The buffer into which bytes will be read.
        /// </param>
        /// <param name="bufferIndex">
        /// The starting index into which bytes will be read (in buffer).
        /// </param>
        /// <param name="length">
        /// The number of bytes to read.
        /// </param>
        /// <returns>
        /// The number of bytes read into the specified buffer.
        /// If the column value is null, then 0 will be returned.
        /// </returns>
        public long GetBytes(string columnName, long dataIndex, byte[] buffer, int bufferIndex, int length)
        {
            int ordinal = this._Reader.GetOrdinal(columnName);
            long result;
            if (this._Reader.IsDBNull(ordinal))
            {
                result = 0L;
            }
            else
            {
                result = this._Reader.GetBytes(ordinal, dataIndex, buffer, bufferIndex, length);
            }
            return result;
        }

        /// <summary>
        /// Reads all data from the specified columnName and return as a byte array..
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <returns>
        /// All data in the column as a byte array.
        /// </returns>
        /// <remarks>
        /// If the column is NULL or contains no data, an empty byte array will be returned.
        /// </remarks>
        public byte[] GetBytes(string columnName)
        {
            int ordinal = this._Reader.GetOrdinal(columnName);
            byte[] result;
            if (this._Reader.IsDBNull(ordinal))
            {
                result = new byte[0];
            }
            else
            {
                MemoryStream memoryStream = new MemoryStream();
                long num = 0L;
                long num2 = 0L;
                byte[] buffer = new byte[65536];
                long bytes;
                do
                {
                    bytes = this._Reader.GetBytes(ordinal, num2, buffer, 0, 65536);
                    if (bytes > 0L)
                    {
                        num2 += bytes;
                        num += bytes;
                        memoryStream.Write(buffer, 0, (int)bytes);
                    }
                }
                while (bytes > 0L);
                memoryStream.Capacity = (int)num;
                result = memoryStream.GetBuffer();
            }
            return result;
        }

        /// <summary>
        /// Gets the length of a varbinary column data.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <returns>
        /// The length, in bytes, of the data in the specified columnName.
        /// </returns>
        public long GetBytesLength(string columnName)
        {
            int ordinal = this._Reader.GetOrdinal(columnName);
            long result;
            if (this._Reader.IsDBNull(ordinal))
            {
                result = 0L;
            }
            else
            {
                result = this._Reader.GetBytes(ordinal, 0L, null, 0, 2147483647);
            }
            return result;
        }

        /// <summary>
        /// Reads characters from the specified columnName into a buffer.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <param name="dataIndex">
        /// The starting index from which characters will be read (from columnName).
        /// </param>
        /// <param name="buffer">
        /// The buffer into which characters will be read.
        /// </param>
        /// <param name="bufferIndex">
        /// The starting index into which characters will be read (in buffer).
        /// </param>
        /// <param name="length">
        /// The number of characters to read.
        /// </param>
        /// <returns>
        /// The number of characters read into the specified buffer.
        /// If the column value is null, then 0 will be returned.
        /// </returns>
        public long GetChars(string columnName, long dataIndex, char[] buffer, int bufferIndex, int length)
        {
            int ordinal = this._Reader.GetOrdinal(columnName);
            long result;
            if (this._Reader.IsDBNull(ordinal))
            {
                result = 0L;
            }
            else
            {
                result = this._Reader.GetChars(ordinal, dataIndex, buffer, bufferIndex, length);
            }
            return result;
        }

        /// <summary>
        /// Gets a DateTime value from the specified columnName.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <returns>
        /// A DateTime value from the specified columnName.  
        /// If the column value is null, then DateTime.MinValue will be returned.
        /// </returns>
        public DateTime GetDateTime(string columnName)
        {
            return this.GetValue<DateTime>(columnName);
        }

        /// <summary>
        /// Gets a DateTime value from the specified columnName.
        /// Guarantees that the DateTimeKind is DateTimeKind.UTC for the returned value.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <returns>
        /// A DateTime value from the specified columnName.  
        /// If the column value is null, then DateTime.MinValue will be returned.
        /// </returns>
        public DateTime GetDateTimeUTC(string columnName)
        {
            DateTime value = this.GetValue<DateTime>(columnName);
            return DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        /// <summary>
        /// Gets a Decimal value from the specified columnName.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <returns>
        /// A Decimal value from the specified columnName.  
        /// If the column value is null, then 0.0 will be returned.
        /// </returns>
        public decimal GetDecimal(string columnName)
        {
            return this.GetValue<decimal>(columnName);
        }

        /// <summary>
        /// Gets a Double value from the specified columnName.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <returns>
        /// A Double value from the specified columnName.  
        /// If the column value is null, then 0.0 will be returned.
        /// </returns>
        public double GetDouble(string columnName)
        {
            return this.GetValue<double>(columnName);
        }

        /// <summary>
        /// Gets a Guid value from the specified columnName.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <returns>
        /// A Guid value from the specified columnName.  
        /// If the column value is null, then Guid.Empty will be returned.
        /// </returns>
        public Guid GetGuid(string columnName)
        {
            return this.GetValue<Guid>(columnName);
        }

        /// <summary>
        /// Gets an Int16 value from the specified columnName.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <returns>
        /// An Int16 value from the specified columnName.  
        /// If the column value is null, then 0 will be returned.
        /// </returns>
        public short GetInt16(string columnName)
        {
            return this.GetValue<short>(columnName);
        }

        /// <summary>
        /// Gets an Int32 value from the specified columnName.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <returns>
        /// An Int32 value from the specified columnName.  
        /// If the column value is null, then 0 will be returned.
        /// </returns>
        public int GetInt32(string columnName)
        {
            return this.GetValue<int>(columnName);
        }

        /// <summary>
        /// Gets an Int64 value from the specified columnName.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <returns>
        /// An Int64 value from the specified columnName.  
        /// If the column value is null, then 0 will be returned.
        /// </returns>
        public long GetInt64(string columnName)
        {
            return this.GetValue<long>(columnName);
        }

        /// <summary>
        /// Gets a Single value from the specified columnName.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <returns>
        /// A Single value from the specified columnName.  
        /// If the column value is null, then 0.0 will be returned.
        /// </returns>
        public float GetSingle(string columnName)
        {
            return this.GetValue<float>(columnName);
        }

        /// <summary>
        /// Gets a String value from the specified columnName.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column.
        /// </param>
        /// <returns>
        /// A String value from the specified columnName.  
        /// If the column value is null, then String.Empty will be returned.
        /// </returns>
        public string GetString(string columnName)
        {
            return this.GetValue<string>(columnName);
        }

        public static T ConvertToType<T>(object value)
        {
            T result;
            if (value == null || value is DBNull)
            {
                result = default(T);
            }
            else
            {
                T t;
                if (typeof(T) == typeof(Guid))
                {
                    object obj = new Guid(value.ToString());
                    t = (T)((object)obj);
                }
                else if (typeof(T) == typeof(bool) && value is string)
                {
                    string text = (string)value;
                    string text2 = text.ToLower();
                    switch (text2)
                    {
                        case "1":
                        case "yes":
                        case "on":
                        case "enable":
                        case "enabled":
                            {
                                object obj2 = true;
                                t = (T)((object)obj2);
                                goto IL_1C0;
                            }
                        case "0":
                        case "no":
                        case "off":
                        case "disable":
                        case "disabled":
                            {
                                object obj3 = false;
                                t = (T)((object)obj3);
                                goto IL_1C0;
                            }
                    }
                    t = (T)((object)Convert.ChangeType(value, typeof(T)));
                IL_1C0: ;
                }
                else
                {
                    t = (T)((object)Convert.ChangeType(value, typeof(T)));
                }
                result = t;
            }
            return result;
        }
    }
}
