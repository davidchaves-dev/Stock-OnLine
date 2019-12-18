using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace DATA_STOCK.Controllers
{
    public class DefaultController : ApiController
    {
        [HttpPost]
        public void UpdateStock([FromBody] MODELS.ItemsList itemsList)
        {
            var threadStock = new Thread(() => asyncUpdateStock(itemsList));
            threadStock.Start();
        }



        private void asyncUpdateStock(MODELS.ItemsList itemsList)
        {
            DATA.SQL.LibertadSAStockEntities stockEntity = new DATA.SQL.LibertadSAStockEntities();
            foreach (Item i in itemsList.Items) {
                stockEntity.UpdateStock(i.ItemCode, itemsList.IdSucursal, decimal.Parse(i.Quantity.ToString()));
                }
        }
    }
}
