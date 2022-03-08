using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ValidationSample.Models
{
    public class User
    {
        [Remote(action: "VerifyEmail", controller: "Users")]
        public string Email { get; set; }

        [Remote(action: "VerifyName", controller: "Users", AdditionalFields = nameof(LastName))]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Remote(action: "VerifyName", controller: "Users", AdditionalFields = nameof(FirstName))]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Remote(action: "VerifyPhone", controller: "Users")]
        public string Phone { get; set; }

        public int Age { get; set; }
    }
}
