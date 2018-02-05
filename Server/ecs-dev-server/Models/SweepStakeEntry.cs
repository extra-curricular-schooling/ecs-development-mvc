using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ecs_dev_server.Models
{
    public class SweepStakeEntry
    {
        [Key]
        public DateTime PurchaseDateTime { get; set; }
        public int cost { get; set; }
    }
}