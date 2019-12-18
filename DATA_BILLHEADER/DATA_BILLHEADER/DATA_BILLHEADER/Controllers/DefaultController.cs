using MODELS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace DATA_BILLHEADER.Controllers
{
    public class DefaultController : ApiController
    {


   


        [HttpPost]
        public void SendHeader([FromBody] MODELS.BillBase billHeader)
        {
            var threadHeader = new Thread(() => AsyncSaveHeader(billHeader));
            threadHeader.Start();
            
        }

        [HttpGet]
        public MODELS.BillBase GetExample()
        {
            return new BillBase();
        }

        public void AsyncSaveHeader(BillBase billHeader)
        {

            MODELS.BillBase MyBB = billHeader;
            if (MyBB.ClientAddress == null) MyBB.ClientAddress = "";
            if (MyBB.ClientDoc == null) MyBB.ClientDoc = "";
            if (MyBB.ClientName == null) MyBB.ClientName = "";

            

            /*DATA.MongoDb.MongoDbTools DbTools = new DATA.MongoDb.MongoDbTools();
            DbTools.insertObject<BillBase>(ConfigurationSettings.AppSettings["ConnectionString"], billHeader, "Bills", "Primary");*/
            DATA.SQL.LibertadSACabeceraFacturaEntities sqlHeader = new DATA.SQL.LibertadSACabeceraFacturaEntities();
            sqlHeader.Insert_DocumentHeader(MyBB.StockSystem, MyBB.IDMessage, MyBB.BranchID, MyBB.TrxId, MyBB.TrxDateTime, MyBB.TrxDocType, MyBB.ClientDoc, MyBB.ClientName, MyBB.ClientAddress, MyBB.GUID);

        }

    }
}
