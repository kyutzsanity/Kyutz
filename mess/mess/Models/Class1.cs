using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mess.Models
{
    public class Class1
    {
        [Required(ErrorMessage = "Enter ID Number")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Numbers only please")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public String fname { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public String lname { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        public String gender { get; set; }
        [Required(ErrorMessage = "Phone Number Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string contact { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string email { get; set; }
        [Required(ErrorMessage = "Please Enter Username")]
        public String Uname { get; set; }
        [Required(ErrorMessage = "Please Password")]
        public String Pword { get; set; }

        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [DataType(DataType.Time)]
        public DateTime time { get; set; }
    }
}