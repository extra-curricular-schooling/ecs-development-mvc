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
        [Key, Required, DataType(DataType.Date), Display(Name = "Purchase Timestamp" )]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd", ApplyFormatInEditMode = true)]
        //[ForeignKey("SweepstakeID, Username")]
        public DateTime PurchaseDateTime { get; set; }

        public int Cost { get; set; }
    }
}