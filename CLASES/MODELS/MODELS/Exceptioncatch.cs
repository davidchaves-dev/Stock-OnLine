using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class Exceptioncatch
    {
        public string msg { get; set; }
        public string request { get; set; }
        public List<Stackcatch> stack { get; set; } = new List<Stackcatch>();
        public Exceptioncatch(System.Exception E) 
        {
            StackTrace trace = new StackTrace(E, true);
            for (int a = 0; a < trace.FrameCount; a++)
            {
                string File = trace.GetFrame(a).GetFileName();
                string Class = trace.GetFrame(a).GetFileName(); ;
                string Method = trace.GetFrame(a).GetMethod().Name;
                string LineNumber = trace.GetFrame(a).GetFileLineNumber().ToString();

                Stackcatch sc = new Stackcatch();
                sc.Class = Class;
                sc.File = File;
                sc.LineNumber = LineNumber;
                sc.Method = Method;
                if (stack == null) { stack = new List<Stackcatch>(); }
                stack.Add(sc);
            }
        }
    }
}
