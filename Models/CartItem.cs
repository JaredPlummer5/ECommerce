using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
  public class CartItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    [ForeignKey("UsersCartId")]
    public int UsersCartId { get; set; }
    public UsersCart UsersCart { get; set; }
    public int Quantity { get; set; } = 1;
}

}