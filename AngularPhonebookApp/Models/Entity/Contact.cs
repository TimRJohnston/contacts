using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularPhonebookApp.Models.Entity
{
    public class Contact
    {
        public int ID { get; set; }
        public string ContactName { get; set; }
        public string Number { get; set; }
        public string SessionID { get; set; }
    }
}
