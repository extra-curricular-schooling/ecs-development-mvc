using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ecs_dev_server.Models
{
    /// <summary>
    /// This model represents the actual sweepstakes held in ECS.  It will contain the winner of a specific
    /// sweepstakes determined through ID and what prize is associated with it.
    /// </summary>
    public class SweepStakes
    {
        //The ID of the sweepstakes
        [Key]
        public int SweepStakesID { get; set; }

        //When the sweepstakes takes place
        [Required, DataType(DataType.DateTime), Display(Name = "Open Timestamp")]
        public DateTime OpenDateTime { get; set; }

        //When the sweepstakes is over
        [Required, DataType(DataType.DateTime), Display(Name = "Closed Timestamp")]
        public DateTime ClosedDateTime { get; set; }

        //The prize associated with a sweepstakes.
        [Required]
        public string Prize { get; set; }

        //The winner chosen for a sweepstakes.  Randomizer logic does not take place here.
        [Display(Name = "Username Winner"), StringLength(20, MinimumLength = 5,
        ErrorMessage = "Username must be between 5-20 characters"), DisplayFormat(NullDisplayText = "No winner")]
        public string UsernameWinner { get; set; }

        //navigation property of sweepstakeentry class
        //a sweepstake can have many sweepstake entries
        public virtual ICollection<SweepStakeEntry> SweepStakeEntry { get; set; }
    }
}