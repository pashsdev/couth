using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PG.Helper
{
    public class ParameterList
    {
        private List<ParameterListItem> _List = new List<ParameterListItem>();
        public List<ParameterListItem> Items
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
            ParameterListItem parameterListItem = this.FindItemByKey(key);
            if (parameterListItem == null)
            {
                this._List.Add(new ParameterListItem
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

        public void Add(string key, object value, SqlDbType sqlDbType)
        {
            ParameterListItem parameterListItem = this.FindItemByKey(key);
            if (parameterListItem == null)
            {
                parameterListItem = new ParameterListItem
                {
                    Key = key,
                    Value = value,
                    SqlDbType = sqlDbType,
                    SqlParameterDirection = ParameterDirection.Input,
                };
                this._List.Add(parameterListItem);
            }
            else
            {
                parameterListItem.Value = value;
                parameterListItem.SqlDbType = sqlDbType;
                parameterListItem.SqlParameterDirection = ParameterDirection.Input;
            }
            parameterListItem._SqlParameterInfoSet = true;
        }

        private ParameterListItem FindItemByKey(string Key)
        {
            return (from pi in this._List
                    where string.Compare(pi.Key, Key, true) == 0
                    select pi).ToList<ParameterListItem>().FirstOrDefault<ParameterListItem>();
        }
    }
}
