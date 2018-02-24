using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ecs_dev_server.Models
{
    /// <summary>
    /// This model represents the entry into a sweepstakes, by buying a raffle, that is modeled in a Sweepstakes class.  
    /// An account can only have one entry per sweepstakes.
    /// </summary>
    public class SweepStakeEntry
    {
        //When the account bought a raffle ticket
        [Required, DataType(DataType.Date), Display(Name = "Purchase Timestamp" )]
        public DateTime PurchaseDateTime { get; set; }

        //The cost of the raffle ticket
        public int Cost { get; set; }

        //Foreign Key of Account class
        [Key,Column(Order = 1), Required, Display(Name = "Username"), StringLength(20, MinimumLength = 5,
        ErrorMessage = "Username must be between 5-20 characters")]
        public string UserName { get; set; }
     
        //Foreign Key of SweepStakes for easy referencing
        [Key, Column(Order = 0)]
        public int SweepstakesID { get; set; }

        //When a raffle ticket for a sweepstakes can be purchased
        public DateTime OpenDateTime { get; set; }
   
        //navigation property of account class
        //a sweepstake entry is mapped to one account
        public virtual Account Account { get; set; }

        //sweepstakes navigation property
        //a sweepstake entry is for one sweepstake
        public virtual SweepStakes SweepStakes { get; set; }

    }
}