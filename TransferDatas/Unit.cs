using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransferDatas
{
    public class Unit
    {
        public Int64 UnitID { get; set; }
        public string UnitName { get; set; }
        public Int64 OracleUnitID { get; set; }
        public bool Active { get; set; }
    }

    public class Units
    {
        public List<Unit> units { get; set; }
    }

    public class UserRights
    {
        public Int64 UnitID { get; set; }
        public Int64 DesignationID { get; set; }
        public Int64 UserID { get; set; }
        public bool IsAvailable { get; set; }
        public string Designation { get; set; }
    }
}
