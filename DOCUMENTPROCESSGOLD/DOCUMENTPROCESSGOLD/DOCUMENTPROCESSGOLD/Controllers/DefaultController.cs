using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using MODELS;

namespace DOCUMENTPROCESSGOLD.Controllers
{
    public class DefaultController : ApiController
    {
        [HttpPost]
        public Response SendStoryStockPage([FromBody] StockPage Story)
        {
           
            string content = new StreamReader(HttpContext.Current.Request.InputStream).ReadToEnd();

            var t = new Thread(()=> asyncWriteLog(content));
            t.Start();
            
            return new Response { code = "200", message = "1" };
        }

        public Response SendStoryMovePage([FromBody] String Story)
        {

            string content = new StreamReader(HttpContext.Current.Request.InputStream).ReadToEnd();

            var t = new Thread(() => asyncWriteLog(content));
            t.Start();

            return new Response { code = "200", message = "" };
        }

        private void asyncWriteLog(string LOG)
        {
            DATA.SQL.GoldLogEntities E = new DATA.SQL.GoldLogEntities();
            E.insert_log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), LOG);
            
        }


    }
}
