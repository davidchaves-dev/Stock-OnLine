using MODELS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Web.Http;

namespace BILLPROCESS.Controllers
{
    public class DefaultController : ApiController
    {
        public static NODO.Nodo Node = new NODO.Nodo(ConfigurationSettings.AppSettings["nodeName"], System.Web.Hosting.HostingEnvironment.MapPath("~"));


        [HttpPost]
        public HttpResponseMessage SendDoc([FromBody]Bill Doc) 
        {

            string GUID = Guid.NewGuid().ToString().Replace("-","");
            BillBase BillHeader = new BillBase(Doc);
            BillHeader.GUID = GUID;
            ItemsList itemsList = new ItemsList();
            itemsList.IdSucursal = Doc.BranchID;
            itemsList.GUID = GUID;
            itemsList.Items = Doc.Items;
            if (Doc == null)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            switch (BillHeader.TrxDocType) 
            {
                case "TCK": itemsList.Operation = "SUB";break;
                case "NDC": itemsList.Operation = "ADD";break;
                case "FAC": itemsList.Operation = "SUB"; break;
                default: itemsList.Operation = "COR";break;
            }
               
            HttpResponseMessage RM;
            if (Doc == null)
            {

                RM = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return RM;
            }


            string EndPointItems = Node.GetGroup("Lars_Items").getCurrentEndPoint().URI;
            string EndPointBillHeader = Node.GetGroup("Lars_BillHeader").getCurrentEndPoint().URI;
            string EndPointCount = Node.GetGroup("Lars_Count").getCurrentEndPoint().URI;


            var threadItems = new Thread(() => asyncSendItems(EndPointItems,itemsList));
            var threadBillHeader = new Thread(() => asyncSendBillHeader(EndPointBillHeader, BillHeader));
            var threadCount = new Thread(() => asyncSendCount(EndPointCount, itemsList));
            threadCount.Start();
            threadBillHeader.Start();
            threadItems.Start();

            
            RM = new HttpResponseMessage(HttpStatusCode.OK);
            return RM;


        }

        private void asyncSendCount(string URI, ItemsList itemsList)
        {
            using (HttpClient HTTPCLIENT = new HttpClient())
            {
                var response = HTTPCLIENT.PostAsync(URI, itemsList, new JsonMediaTypeFormatter());
                if (response.Result.StatusCode != HttpStatusCode.OK)
                {

                }
                else
                {
                }
            }
        }

        private void asyncSendBillHeader(string URI, BillBase billBase)
        {
            using (HttpClient HTTPCLIENT = new HttpClient())
            {
                var response = HTTPCLIENT.PostAsync(URI, billBase, new JsonMediaTypeFormatter());
                if (response.Result.StatusCode != HttpStatusCode.OK)
                {

                }
                else
                {
                }
            }
        }

        private void asyncSendItems(string URI, ItemsList itemsList) 
        {
            using (HttpClient HTTPCLIENT = new HttpClient())
            {
                var response = HTTPCLIENT.PostAsync(URI, itemsList, new JsonMediaTypeFormatter());
                if (response.Result.StatusCode != HttpStatusCode.OK)
                {

                }
                else
                {
                }
            }
        }



    }
}
