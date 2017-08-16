using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace TransferDatas
{
    public class User
    {
        public Int64 UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsApprover { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string ResetPassword { get { return "Reset"; } }
    }

    public class UserUnits
    {
        public Int64 UserUnitID { get; set; }
        public Int64 UserID { get; set; }
        public Int64 UnitID { get; set; }
        public string Unit { get; set; }
        public Boolean FullRights { get; set; }
        public Boolean ViewRights { get; set; }
    }

    public class Users
    {
        public List<User> users { get; set; }
        public List<UserUnits> userUnits { get; set; }
    }
}
