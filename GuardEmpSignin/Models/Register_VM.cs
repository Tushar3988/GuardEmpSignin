﻿using System.ComponentModel.DataAnnotations;
namespace GuardEmpSignin.Models
{
    public class Register_VM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Not Matched with the Password Field.")]
        public string ConfirmPassword { get; set; }
    }
}