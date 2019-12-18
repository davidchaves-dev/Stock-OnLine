using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class StockPage
    {
        public int page { get; set; }
        public int maxPage { get; set; }
        public string dateTime { get; set; }
        public List<ArtGold> Listart { get; set; }
    }
}
