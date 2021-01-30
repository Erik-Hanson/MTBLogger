using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTBLogger.Models
{
    public class ToRide
    {
        [Key]
        public int LogId { get; set; } // Not to be confused with LogId from Logged
                                       // seems like the most fitting name here still
        [Required]
        [DisplayName("Trail Name")]
        public string TrailName { get; set; }

        public int? UserId { get; set; }
    }
}
