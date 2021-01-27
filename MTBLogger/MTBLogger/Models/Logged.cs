using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTBLogger.Models
{
    public class Logged
    {
        [Key]
        public int LogId { get; set; }
        
        [Required]
        [DisplayName("Trail Name")]
        public string TrailName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int? UserId { get; set; }
    }
}
