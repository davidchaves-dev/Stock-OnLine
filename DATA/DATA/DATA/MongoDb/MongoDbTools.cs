using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.MongoDb
{
    public class MongoDbTools
    {

        public static MongoClient MC = null;
        public static object o = new object();
        public void insertObject<T>(string ConnectionString, T Object, string Database, string Collection) 
        {
            MongoUrl MRL = new MongoUrl(ConnectionString);
            
            lock (o) {
                if (MC == null) 
                {
                    MC = new MongoClient(ConnectionString);
                }
            IMongoDatabase MDB = MC.GetDatabase(Database);
            IMongoCollection<T> COL =  MDB.GetCollection<T>(Collection);
            COL.InsertOne(Object);
            }
        }
    }
}
