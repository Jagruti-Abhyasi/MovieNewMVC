﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieNewMVC.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter Customer Name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSunscribedToNewsletter { get; set; }
        public Membership MembershipType { get; set; }
        [Display(Name="Membership Type")]
        public byte MembershipId { get; set; }
        [Display(Name="Date of Birth")]
        [Min18AgeIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}