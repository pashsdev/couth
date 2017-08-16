using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PG.Helper
{
    public class OracleParameterListItem
    {
        internal bool _OracleParameterInfoSet = false;
        /// <summary>
        /// Gets or sets the key for the ParameterListItem.
        /// </summary>
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value for the ParameterListItem.
        /// </summary>
        public object Value
        {
            get;
            set;
        }

        internal OracleDbType OracleDbType
        {
            get;
            set;
        }

        internal ParameterDirection OracleParameterDirection
        {
            get;
            set;
        }
    }
}
