using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransferDatas
{
    public class Reprintable
    {
        public Int64 Sno { get; set; }
        public string Serial_Number { get; set; }
        public string Jobnumber { get; set; }
        public string Item_Code { get; set; }
        public string Description { get; set; }
    }

    public class ReprintMaster
    {
        public Int64 ReprintID { get; set; }
        public string ReprintNo { get; set; }
        public DateTime RequestDate { get; set; }
        public Int64 RequestUserID { get; set; }
        public string RequestUser { get; set; }
        public bool Approved { get; set; }
        public Int64 ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string ApprovedByUser { get; set; }
    }

    public class ReprintDetails
    {
        public string ReprintNo { get; set; }
        public Int64 ReprintDetailsID { get; set; }
        public Int64 ReprintID { get; set; }
        public string Serial_Number { get; set; }
        public string Jobnumber { get; set; }
        public string Item_Code { get; set; }
        public string Description { get; set; }
    }
}
