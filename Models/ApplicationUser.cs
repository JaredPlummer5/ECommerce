using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class ApplicationUser : IdentityUser
    {


        public string Password { get; set; }

        //public string Email { get; set; }

        //public string PhoneNumber { get; set; }
        [NotMapped]
        public string? Token { get; set; }

        [NotMapped]
        public IList<string>? Roles { get; set; }

    
    }

}

