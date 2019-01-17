using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiuroPodrozyCzapeczka.App_Start;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BiuroPodrozyCzapeczka.Controllers
{
    public class MongoDBController : Controller
    {
        MongoContext _dbContext;
        // GET: MongoDB
        public ActionResult Index()
        {

            return View();
        }
        public void MongolDB(String Stacktrace, String Msg, DateTime date)
        {
            var MyClient = new MongoClient();
            var MyMongoDB = MyClient.GetDatabase("Czapeczka");
            var MyCollection = MyMongoDB.GetCollection<BsonDocument>("Logs");
            var MyDocument = new BsonDocument
                 {
                     {"StackTrace", Stacktrace},
                     {"Message", Msg},
                     {"Date", date},

                 };
            MyCollection.InsertOne(MyDocument);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        public ActionResult Create(FormCollection Collection)
        {
            try
            {
                return RedirectToAction("Index");
             }
            catch {
                return View();
            }
            }
    }
}