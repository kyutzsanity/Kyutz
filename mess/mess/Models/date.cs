using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mess.Models
{
    public class date
    {
        [Required(ErrorMessage = "Enter ID Number")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Numbers only please")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter Room")]
        public String Room { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateofuse { get; set; }
        [DataType(DataType.Time)]
        public DateTime timeofuse { get; set; }
        [DataType(DataType.MultilineText)]
        public string purpose { get; set; }
        public String Lab { get; set; }
    }
}