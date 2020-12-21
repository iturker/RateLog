using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using KurLog.Classes;

namespace KurLog.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter your First Name")]
        [StringLength(50, ErrorMessage = "The number of characters must be 50")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter your Last Name")]
        [StringLength(50, ErrorMessage = "The number of characters must be 50")]
        public string LastName { get; set; }
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please enter your User Name")]
        [StringLength(50, ErrorMessage = "The number of characters must be 50")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "Password")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }
        [Display(Name = "Authority")]
        [Required(ErrorMessage = "Please enter your Authority")]
        [StringLength(50, ErrorMessage = "The number of characters must be 50")]
        public string Authority { get; set; }
        public bool IsDelete { get; set; }
        
    }
}
