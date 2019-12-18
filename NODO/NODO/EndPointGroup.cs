using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NODO
{
    public class EndPointGroup
    {
        
        public String Name { get; set; }
        public List<EndPoint> endPointList { get; set; }
        [NonSerialized]
        public int pointer=0;
        private static readonly Object obj = new Object();


        public EndPointGroup(string name)
        {
            this.Name = name;
            endPointList = new List<EndPoint>();
        }

      
        public EndPoint getCurrentEndPoint()
        {
            lock(obj) { 
            int currentEP = pointer;
            pointer++;
            if (pointer > endPointList.Count - 1)
            {
                pointer = 0;
            }
            return endPointList[currentEP];
            }
        }

        

        public void AddEndPoint(String URI)
        {
            if (endPointList == null)
            {
                endPointList = new List<EndPoint>();
            }
            endPointList.Add(new EndPoint(URI));
        }

    }
}
