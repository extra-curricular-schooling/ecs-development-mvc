using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ecs_dev_server.Models
{
    /// <summary>
    /// This model represents the address information associated with a given user.  It does not contain any type of
    /// validation logic, it simply stores information given during registration.
    /// </summary>
    public class ZipLocation
    {
        //The area code given during registration
        [Required, Key, Display(Name = "Zip Code"), 
        StringLength(10, MinimumLength = 5, ErrorMessage = "Zipcode must be 5-10 characters")] 
        public string ZipCode { get; set; }
        
        //The street number and street given during registration
        [Required]
        public string Address { get; set; }

        //The city given during registration
        [Required]
        public string City { get; set; }

        //The state given during registration
        [Required]
        public string State { get; set; }

        //The latitude of a given location.  This is optional because our system only refers to the SoCAL area
        //Thus there should not be any duplicate combinations of cities streets and zipcodes.
        public int Latitude { get; set; }

        //The longitude of a given location.  This is optional because our system only refers to the SoCAL area
        //Thus there should not be any duplicate combinations of cities streets and zipcodes.
        public int Longitude { get; set; }
    }
}