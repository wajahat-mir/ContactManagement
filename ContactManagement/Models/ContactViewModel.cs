using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Models
{
    public class ContactViewModel
    {
        public int id { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string name { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }
        [Required]
        [Display(Name = "Company")]
        public string company { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string phone { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Last Date Contacted")]
        public DateTime lastDateContacted { get; set; }
        public string comments { get; set; }
    }
}
