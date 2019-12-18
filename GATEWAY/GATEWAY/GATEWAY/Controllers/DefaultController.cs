using DATA.MongoDb;
using MODELS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GATEWAY.Controllers
{
    public class LOG
    {
        public long id { get; set; }
        public string content { get; set; }
    }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DefaultController : ApiController
    {

        public static NODO.Nodo N = new NODO.Nodo(ConfigurationSettings.AppSettings["nodeName"], System.Web.Hosting.HostingEnvironment.MapPath("~"));

        [HttpPost]
        [Route("api/default/GetJsonLog/{ID}")]
        public List<LOG> GetJsonLog(int ID)
        {
            List<LOG> Lista = new List<LOG>();
            DATA.SQL.RequestLogEntities RLE = new DATA.SQL.RequestLogEntities();
            IEnumerable<DATA.SQL.GetLog_Result> a = RLE.GetLog(ID);

            foreach (DATA.SQL.GetLog_Result R in a)
            {
                LOG obj = new LOG { id = R.Id, content = R.Content };
                Lista.Add(obj);
            }
            return Lista;
            
        }

        [HttpGet]
        public string test() 
        {
            return "Prueba de api: dirigirse a POST: /api/default/sendDoc";
        }

        [HttpGet]
        public void SendStock()
        {
            //Primera carga gold
        }

        [HttpGet]
        public void SendUpdate()
        {
            //Envio movimientos gold
        }

        [HttpGet]
        public MODELS.Bill getexample()
        {
            var tBill = new Bill();
            tBill.Items = new List<Item>();
            tBill.Items.Add(new Item());
            return tBill;
        }

        [HttpPost]
        public MODELS.Response sendDoc([FromBody] MODELS.Bill Doc)
        {

            HttpResponseMessage RM;
            if (Doc == null) {

               RM = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                /*
                MongoDbTools b = new DATA.MongoDb.MongoDbTools();
                b.insertObject<HttpResponseMessage>("mongodb://localhost:27017", RM, "PruebaEmma", "error");*/
                
                throw new HttpResponseException(RM);
               
            }
            MODELS.Response R = new MODELS.Response { code = "200", message = "Ticket validado y en proceso" };
            /*MongoDbTools a = new DATA.MongoDb.MongoDbTools();
            a.insertObject<MODELS.Bill>("mongodb://localhost:27017", Doc, "PruebaEmma", "prueba");*/

            //RawBufferManual();

            string content = new StreamReader(HttpContext.Current.Request.InputStream).ReadToEnd();
            asyncWriteLog(content);

            string EndPoint = N.GetGroup("Lars").getCurrentEndPoint().URI;
            var t = new Thread(() => asyncSend(EndPoint, Doc));
            t.Start();
            
            return R;
        }

        
        public async void PostRawBufferManual()
        {
            string result = await Request.Content.ReadAsStringAsync();
            asyncWriteLog(result);
        }


        private void asyncWriteLog(string LOG)
        {
            DATA.SQL.RequestLogEntities RequestLog = new DATA.SQL.RequestLogEntities();
            RequestLog.InsertLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), LOG);
        }

        private void asyncSend(string URI, Bill Doc) 
        {

            using (HttpClient HTTPCLIENT = new HttpClient())
            {
                var response = HTTPCLIENT.PostAsync(URI, Doc, new JsonMediaTypeFormatter());
                if (response.Result.StatusCode != HttpStatusCode.OK)
                {
                    
                }
                else
                {

                }
            }
      
        }


        

        [HttpGet]
        public bool Restart()
        {
            if (Request.IsLocal()) System.Web.HttpRuntime.UnloadAppDomain();
            return Request.IsLocal();
            
        }

        [HttpGet]
        public NODO.Nodo GetConfig()
        {
                return N;
        }
        [HttpGet]
        [Route("api/default/insertgroup/{groupName}")]
        public bool InsertGroup(string groupName)
        {
            if (N != null && groupName!=null)
            {
                N.AddGroup(groupName);
            }
            return true;
        }

        [HttpGet]
        [Route("api/default/insertendpoint/{groupName}/{uri}/{port}")]
        public bool InsertEndPoint(string groupName, string uri, string port)
        {
            N.AddEndPoint(groupName, uri+":"+port);
            return true;
        }
    }
}
