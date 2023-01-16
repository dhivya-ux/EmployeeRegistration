using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class ProductModel
    { 


        [DisplayName("Last Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "First Name should be minimum 3 characters and a maximum of 50 characters")]
        public string LastName { get; set; }
        [DisplayName("First Name")]
        public string Firstname { get; set; }
        [DisplayName("Nationality")]
        public string Nationality { get; set; }
        [DisplayName("Place of Birth")]
        public string PlaceofBirth { get; set; }
        [DisplayName("Country of Birth")]
        public string CountryofBirth { get; set; }
        public string Gender { get; set; }
        [DisplayName("Telephone Number")]
        public double TelephoneNumber { get; set; }
       [DisplayName("Email Address")]
        public string EmailAddress { get; set; }


    }
}