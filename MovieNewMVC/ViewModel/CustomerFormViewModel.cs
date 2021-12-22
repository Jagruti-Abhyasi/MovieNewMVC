using MovieNewMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieNewMVC.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<Membership> Memberships { get; set; }
        public Customer Customer { get; set; }
    }
}