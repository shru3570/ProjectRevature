using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectDemo.UIMOdel
{
    
     
        public class User
        {
            [Key]
            public int UserId { get; set; }
            [Required(ErrorMessage = "First Name Is required.")]
            public String FirstName { get; set; }

            [Required(ErrorMessage = "Last Name Is required.")]
            public String LastName { get; set; }
            [DataType(DataType.EmailAddress)]

            [Required(ErrorMessage = "Please enter Email ID")]
            [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
            public String EmailId { get; set; }

            [Required(ErrorMessage = "UserName Is required.")]
            public String UserName { get; set; }

            [Required(ErrorMessage = "Password  Is required.")]
            [DataType(DataType.Password)]
            public String Password { get; set; }
            [Compare("Password", ErrorMessage = "Please confirm Your Password")]
            [DataType(DataType.Password)]
            public String ConfirmPassword { get; set; }

            public DateTime UserCreated { get; set; }
            public int? RoleId { get; set; }
            public string RoleName { get; set; }

        }
        
    
}
