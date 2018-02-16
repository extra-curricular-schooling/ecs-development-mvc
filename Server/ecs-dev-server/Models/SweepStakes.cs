using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ecs_dev_server.Models
{
    public class SweepStakes
    {
        //[Required]
        [Key, Display(Name = "Sweepstakes ID")]
        public int SweepStakesID { get; set; }

        [Required, DataType(DataType.DateTime), Display(Name = "Open Timestamp")]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd-hh:mm", ApplyFormatInEditMode = true)]
        public DateTime OpenDateTime { get; set; }

        [Required, DataType(DataType.DateTime), Display(Name = "Closed Timestamp")]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd-hh:mm", ApplyFormatInEditMode = true)]
        public DateTime ClosedDateTime { get; set; }

        [Required]
        public string Prize { get; set; }

        [Required, Display(Name = "Username Winner")]
        public string UsernameWinner { get; set; }
    }
}