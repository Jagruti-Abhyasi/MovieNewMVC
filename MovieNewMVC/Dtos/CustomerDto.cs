using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieNewMVC.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSunscribedToNewsletter { get; set; }
        // we sould exclude memship this is a domain class and this property here creating a 
        // dependencies from out dto to our domain model
        //public Membership MembershipType { get; set; }
        
        public byte MembershipId { get; set; }
        
        public DateTime? Birthdate { get; set; }
        
        public MembershipTypeDto MembershipType { get; set; }

    }
}