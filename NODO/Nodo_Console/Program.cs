using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodo_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            NODO.Nodo N = new NODO.Nodo("Node16", AppContext.BaseDirectory);
            N.AddGroup("grup1");
            N.AddEndPoint("grup1", "1www.google.com.ar");
            N.AddEndPoint("grup1", "2www.google.com.ar");
            
            N.AddGroup("grup2");
            N.AddEndPoint("grup2", "4www.google.com.ar");
            N.AddEndPoint("grup2", "5www.google.com.ar");
            

           
            
        }
    }
}
