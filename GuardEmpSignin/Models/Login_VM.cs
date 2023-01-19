using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GuardEmpSignin.Models
{
    public class Login_VM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}

