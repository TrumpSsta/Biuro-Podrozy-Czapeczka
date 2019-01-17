using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiuroPodrozyCzapeczka.Models
{
    public class MongoDB 
    {
        public object _id { get; set; } //MongoDb uses this field as identity.

        public int ID { get; set; }

        public string UserName { get; set; }
        public string LoginDate { get; set;}
        public string LoginTime { get; set; }

    }
}