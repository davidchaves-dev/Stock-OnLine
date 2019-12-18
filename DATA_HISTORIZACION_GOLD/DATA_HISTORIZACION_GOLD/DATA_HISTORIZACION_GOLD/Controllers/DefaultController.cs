using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace DATA_HISTORIZACION_GOLD.Controllers
{
    public class DefaultController : ApiController
    {

        [HttpPost]
        public Response SendStockPage([FromBody] StockPage stockPage) 
        {
            if (stockPage != null)
            {
                DATA.SQL.StoryGOLDEntities GE = new DATA.SQL.StoryGOLDEntities();
                foreach (ArtGold sm in stockPage.Listart)
                {
                    GE.InsertStock(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), stockPage.page, sm.CodArt, sm.CodSuc, sm.Cant);
                }
                return new Response { code = 200.ToString(), message = "Stock page en proceso" };
            }
            else 
            {
                return new Response { code = 500.ToString(), message = "Error en recepcion o formato incorrecto..." };
            }
        }

        public Response SendMovePage([FromBody] StockMove movePage) 
        {
            if (movePage != null)
            {
                DATA.SQL.StoryGOLDEntities GE = new DATA.SQL.StoryGOLDEntities();
                foreach (ArtMov m in movePage.Items)
                {
                    GE.InsertMove(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), m.CodArt, m.Cant, m.TipoMov, m.BranchCod);
                }
                return new Response { code = 200.ToString(), message = "en proceso" };
            }
            else 
            {
                return new Response { code = 500.ToString(), message = "Error en recepcion o formato incorrecto..." };
            }
        }
            
    }
}
