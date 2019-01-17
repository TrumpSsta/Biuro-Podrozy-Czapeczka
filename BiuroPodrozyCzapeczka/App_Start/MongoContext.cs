using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;
using MongoDB.Bson;

namespace BiuroPodrozyCzapeczka.App_Start
{
    public class MongoContext
    {
       
      
       public void  Mongos(String miejsce, String Stacktrace, String Msg, DateTime date)
        {
            var MyClient = new MongoClient();
            var MyMongoDB = MyClient.GetDatabase("Czapeczka");
            var MyCollection = MyMongoDB.GetCollection<BsonDocument>("Logs");
            var MyDocument = new BsonDocument
                 {
                     {"Miejsce", miejsce},
                     {"StackTrace", Stacktrace},
                     {"Wiadomość", Msg},
                     {"Data", date},

                 };
            MyCollection.InsertOne(MyDocument);
        }
    }
}