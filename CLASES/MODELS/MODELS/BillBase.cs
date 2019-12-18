using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{



    public class BillBase
    {
        public string StockSystem { get; set; }
        public string IDMessage { get; set; }
        public string BranchID { get; set; }
        public string TrxId { get; set; }
        public string TrxDateTime { get; set; }
        public string TrxDocType { get; set; }
        public string ClientDoc { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public string GUID { get; set; }

        public BillBase() { }
        public BillBase(Bill B) 
        {
            StockSystem = B.StockSystem;
            IDMessage = B.IDMessage;
            BranchID = B.BranchID;
            TrxId = B.TrxId;
            TrxDateTime = B.TrxDateTime;
            TrxDocType = B.TrxDocType;
            ClientDoc = B.ClientDoc;
            ClientName = B.ClientName;
            ClientAddress = B.ClientAddress;
        }

        public BillBase GetThis()
        {
            return this as BillBase;
        }

    }
}
