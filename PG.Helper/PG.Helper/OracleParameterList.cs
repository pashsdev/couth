using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PG.Helper
{
    public class OracleParameterList
    {
        private List<OracleParameterListItem> _List = new List<OracleParameterListItem>();
        public List<OracleParameterListItem> Items
        {
            get
            {
                return this._List;
            }
            set
            {
                this._List = value;
            }
        }

        public void Set(string key, object value)
        {
            if (this.FindItemByKey(key) == null)
            {
                throw new ArgumentException("The specified Key in the ParameterList does not exist.");
            }
            this.Add(key, value);
        }

        public void Add(string key, object value)
        {
            OracleParameterListItem parameterListItem = this.FindItemByKey(key);
            if (parameterListItem == null)
            {
                this._List.Add(new OracleParameterListItem
                {
                    Key = key,
                    Value = value
                });
            }
            else
            {
                parameterListItem.Value = value;
            }
        }

        public void Add(string key, object value, OracleDbType oracleDbType)
        {
            OracleParameterListItem parameterListItem = this.FindItemByKey(key);
            if (parameterListItem == null)
            {
                parameterListItem = new OracleParameterListItem
                {
                    Key = key,
                    Value = value,
                                                            OracleDbType = oracleDbType,

                    OracleParameterDirection = ParameterDirection.Input,
                };
                this._List.Add(parameterListItem);
            }
            else
            {
                parameterListItem.Value = value;
                parameterListItem.OracleDbType = oracleDbType;
                parameterListItem.OracleParameterDirection = ParameterDirection.Input;
            }
            parameterListItem._OracleParameterInfoSet = true;
        }

        public void Add(string key, OracleDbType oracleDbType, ParameterDirection parameterDirection )
        {
            OracleParameterListItem parameterListItem = this.FindItemByKey(key);
            if (parameterListItem == null)
            {
                parameterListItem = new OracleParameterListItem
                {
                    Key = key,
                    OracleDbType = oracleDbType,
                    OracleParameterDirection = parameterDirection,
                };
                this._List.Add(parameterListItem);
            }
            else
            {
                parameterListItem.OracleDbType = oracleDbType;
                parameterListItem.OracleParameterDirection = parameterDirection;
            }
            parameterListItem._OracleParameterInfoSet = true;
        }

        private OracleParameterListItem FindItemByKey(string Key)
        {
            return (from pi in this._List
                    where string.Compare(pi.Key, Key, true) == 0
                    select pi).ToList<OracleParameterListItem>().FirstOrDefault<OracleParameterListItem>();
        }
    }
}
