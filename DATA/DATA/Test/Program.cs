using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{

    public class Perro
    {
        public int patas { get; set; }
        public int colas { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MODELS.Bill B = new MODELS.Bill();
            B.BranchID = "13278";
            B.ClientAddress = "";
            B.ClientDoc = "";
            B.ClientName = "";
            B.GUID = Guid.NewGuid().ToString();
            B.IDMessage = "13";
            B.StockSystem = "LARS";
            B.TrxDateTime = "20191010101010";
            B.TrxDocType = "TCK";
            B.TrxId = "120932890183";
            
            List<MODELS.Item> LI = new List<MODELS.Item>();
            Random R = new Random(DateTime.Now.Millisecond);
            for (int a = 0; a < 100; a++) { 
            LI.Add(new MODELS.Item { ItemCode = R.Next(11111,99999).ToString(), Quantity = 1f });
            }
            Dictionary<string, Perro> lista = new Dictionary<string, Perro>();
            lista.Add("firulais", new Perro { colas=3, patas=2 });
            B.Items = LI;
            DATA.MongoDb.MongoDbTools T = new DATA.MongoDb.MongoDbTools();
            Stopwatch SW = new Stopwatch();
            Console.WriteLine("Press enter");
            Console.ReadLine();
            /*DATA.SQL.LibertadSADetalleFacturaEntities E = new DATA.SQL.LibertadSADetalleFacturaEntities();

            SW.Start();
            for (int a = 0; a < 500; a++)
            {
                
                E.Insert_DocumentItem("92347342", 100m, "1238731");
            }
            SW.Stop();*/

            Perro P = new Perro { colas = 4, patas = 5 };

            SW.Start();
            for (int a = 0; a < 120; a++)
            {
                
                T.insertObject<Perro>("mongodb://localhost:27017/prueba", P, "animales", "caninos");
            }

            SW.Stop();
            Console.WriteLine(SW.ElapsedMilliseconds.ToString());
            Console.ReadLine();


        }
    }
}
