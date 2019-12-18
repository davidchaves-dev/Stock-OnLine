using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Web.Hosting;
using System.Web.Http;
using MODELS;

namespace DATA_ITEMS.Controllers
{

    public class ASM
        {
        public string NAME { get; set; }
        public string VERSION { get; set; }
    }

    public class DefaultController : ApiController
    {
        [HttpGet]
        public List<ASM> GetASM()
        {
            string hi = HostingEnvironment.MapPath("/");
            string[] files = Directory.GetFiles(hi + "/bin", "*.dll");
            List<ASM> LOASM = new List<ASM>();
            foreach (string f in files)
            {
                string name;
                string version;
                name = AssemblyName.GetAssemblyName(f).Name;
                version = AssemblyName.GetAssemblyName(f).Version.ToString();
                LOASM.Add(new ASM { NAME = name, VERSION = version });
            }
            
            return LOASM;
        }

        [HttpGet]
        public MODELS.ItemsList GetExample()
        {
            ItemsList il = new ItemsList();
            il.Items = new List<Item>();
            il.Items.Add(new Item());
            il.Items.Add(new Item());
            il.Items.Add(new Item());
            il.Items.Add(new Item());
            return il;
        }

        [HttpPost]
        public void SendItems([FromBody] MODELS.ItemsList itemsList)
        {
            var threadItems = new Thread(() => AsyncInsertAll(itemsList));
            threadItems.Start();
        }

        public void AsyncInsertAll(ItemsList il)
        {
            DATA.SQL.LibertadSADetalleFacturaEntities E = new DATA.SQL.LibertadSADetalleFacturaEntities();
            foreach (Item i in il.Items)
            {
                E.Insert_DocumentItem(i.ItemCode, Convert.ToDecimal(i.Quantity), il.GUID, i.Exclusive,i.ECommerce);
            }
        }
    }
}