﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class StockMove
    {
        public string DateTime { get; set; }
        public List<ArtMov> Items { get; set; }
    }
}
