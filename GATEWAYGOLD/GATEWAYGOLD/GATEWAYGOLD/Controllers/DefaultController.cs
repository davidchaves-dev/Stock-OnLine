using NODO;
using MODELS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;
using System.Net.Http.Formatting;

namespace GATEWAYGOLD.Controllers
{
    public class DefaultController : ApiController
    {

        public static NODO.Nodo Node = new Nodo(ConfigurationSettings.AppSettings["nodeName"], System.Web.Hosting.HostingEnvironment.MapPath("~"));


        [HttpGet]
        [Route("api/default/GetExampleStockPage/{cant}")]
        public StockPage GetExampleStockPage(int cant) 
        {
            Random R = new Random();
            List<ArtGold> lg = new List<ArtGold>();
            for (int a = 0; a < cant; a++) { 
            ArtGold ag = new ArtGold { Cant = R.Next(1,100), CodArt = R.Next(10000, 20000).ToString(), CodSuc = R.Next(100, 108).ToString() };
                lg.Add(ag);
            }
            HttpClient HTTPCLIENT = new HttpClient();
            return new StockPage { dateTime = "20190808080808", Listart = lg, maxPage = 100, page = 1 };
        }
        [HttpGet]
        [Route("api/default/GetExampleStockMove/{cant}")]
        public StockMove GetExampleStockMove(int cant)
        {
            Random R = new Random();
            List<ArtMov> lm = new List<ArtMov>();
            for (int a = 0; a < cant; a++)
            {
                ArtMov am = new ArtMov { BranchCod = R.Next(100, 105).ToString(), Cant = R.Next(1, 10), CodArt = R.Next(1000, 1100).ToString(), TipoMov = R.Next(1, 3) == 1 ? "ADD" : "SUB" };
                lm.Add(am);
            }
            StockMove SM = new StockMove { DateTime = DateTime.Now.ToString("yyyyMMddHHmmss"), Items = lm };
            return SM;
        }


        [HttpPost]
        public Response InsertStockMove([FromBody] StockMove Moves)
        {
            if (Moves != null)
            {
                var ThreadInsertStockPage = new Thread(() => InsertMovAsync(Moves));
                ThreadInsertStockPage.Start();
                var ThreadInsertStory = new Thread(() => InsertStoryAsync(Moves));
                ThreadInsertStory.Start();
                return new Response { code = "202", message = "Movimientos en proceso..." };
            }
            else
            {
                return new Response { code = "500", message = "Error de envio..." };
            }
        }

        [HttpPost]
        public Response InsertStockPage([FromBody] StockPage Page) 
        {
            if (Page != null)
            {
                var ThreadInsertStockPage = new Thread(() => InsertStockPageAsync(Page));
                ThreadInsertStockPage.Start();
                var ThreadInsertStory = new Thread(() => InsertStoryAsync(Page));
                ThreadInsertStory.Start();
                return new Response { code = "202", message = "Página en proceso..." };
            }
            else
            {
                return new Response { code = "500", message = "Error de envio..." };
            }

        }

        private async void InsertMovAsync(StockMove Move)
        {

        }

       

        private async void InsertStockPageAsync(StockPage Page)
        {

        }

        private async void InsertStoryAsync(StockPage Page)
        {
            HttpClient client = new HttpClient();
            
            

            using (HttpClient HTTPCLIENT = new HttpClient())
            {
                var response = HTTPCLIENT.PostAsync(Node.GetGroup("GOLD_Process_Story_StockPage").getCurrentEndPoint().URI,Page , new JsonMediaTypeFormatter());
                if (response.Result.StatusCode != HttpStatusCode.OK)
                {

                }
                else
                {

                }
            }

        }

        private async void InsertStoryAsync(StockMove Page)
        {
            HttpClient client = new HttpClient();



            using (HttpClient HTTPCLIENT = new HttpClient())
            {
                var response = HTTPCLIENT.PostAsync(Node.GetGroup("GOLD_Process_Story_MovePage").getCurrentEndPoint().URI, Page, new JsonMediaTypeFormatter());
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

