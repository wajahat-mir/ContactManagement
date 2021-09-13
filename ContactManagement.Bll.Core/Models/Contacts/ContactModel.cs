using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Bll.Core.Models.Contacts
{
    public class ContactModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string company { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string comments { get; set; }
        public DateTime lastDateContacted { get; set; }
    }
}
