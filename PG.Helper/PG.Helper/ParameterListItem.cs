using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace PG.Helper
{
    public class ParameterListItem
    {
        internal bool _SqlParameterInfoSet = false;

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

        internal SqlDbType SqlDbType
        {
            get;
            set;
        }

        internal ParameterDirection SqlParameterDirection
        {
            get;
            set;
        }

        
    }
}
