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
        public Int64 Sno { get; set; }
        public Int64 ReprintID { get; set; }
        public string ReprintNo { get; set; }
        public DateTime RequestDate { get; set; }
        public Int64 RequestUserID { get; set; }
        public string RequestUser { get; set; }
        public Int64 UnitID { get; set; }
        public string Unit { get; set; }
        public string Code { get; set; }
        public Int64 OracleUnitID { get; set; }
    }

    public class ReprintDetails
    {
        public Int64 Sno { get; set; }
        public Int64 ReprintID { get; set; }
        public string ReprintNo { get; set; }
        public DateTime RequestDate { get; set; }
        public Int64 ReprintDetailsID { get; set; }
        public Int64 RequestUserID { get; set; }
        public string RequestUser { get; set; }
        public string ApprovedStatus { get; set; }
        public Int64 ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string ApprovedByUser { get; set; }
        public string ApprovalRemarks { get; set; }
        public Int64 UnitID { get; set; }
        public string Serial_Number { get; set; }
        public string Jobnumber { get; set; }
        public string Item_Code { get; set; }
        public string Description { get; set; }
        public Int64 TemplateID { get; set; }
        public string Template { get; set; }
        public string Remarks { get; set; }
        public Int64 PrintCount { get; set; }
        public string Code { get; set; }
        public Int64 OracleUnitID { get; set; }
    }
}
