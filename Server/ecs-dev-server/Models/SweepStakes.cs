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
        [Key]
        public int SweepStakesID { get; set; }

        public DateTime OpenDateTime { get; set; }

        public DateTime ClosedDateTime { get; set; }

        public string Prize { get; set; }

        public string UsernameWinner { get; set; }
    }
}