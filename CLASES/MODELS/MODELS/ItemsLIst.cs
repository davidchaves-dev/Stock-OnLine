using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class ItemsList
    {

        public String IdSucursal { get; set; }
        public List<Item> Items { get; set; }
        public string GUID { get; set; }
        public string Operation { get; set; }

    }
}
