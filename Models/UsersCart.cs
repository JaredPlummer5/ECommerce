using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class UsersCart
    {
        [Key]
        public int Id { get; set; }

        public ApplicationUser? UserData { get; set; }

        [ForeignKey("UserId")]
        public string? UserId { get; set; }

    public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}

