using System.Net;
using ECommerce.Models;
using ECommerce.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private JwtTokenService tokenService;

        private ECommerceDbContext context;

        public UsersController(ECommerceDbContext Context, UserManager<ApplicationUser> manager, JwtTokenService _tokenService, SignInManager<ApplicationUser> _signInManager)
        {

            context = Context;
            userManager = manager;
            tokenService = _tokenService;
            signInManager = _signInManager;
        }

        // ROUTES

        [HttpPost("Register")]
        [AllowAnonymous]

        public async Task<ActionResult<ApplicationUser>> Register(ApplicationUser user)
        {
            // Note: data (RegisterUser) comes from an inbound DTO/Model created for this purpose
            // this.ModelState?  This comes from MVC Binding and shares an interface with the Model
            //var user = await userService.Register(data, this.ModelState);

            var result = await userManager.CreateAsync(user, user.Password);
            if (result.Succeeded)
            {
                // await userManager.AddToRolesAsync(user, user.Roles);
                // var name = HttpContext.User.Identity.Name;

                List<string> roles = new List<string>
                {
                    "Anonymous"
                };
                //await userManager.AddToRoleAsync(user, roles.ToString()); // Example role
                await signInManager.SignInAsync(user, null);

                return new ApplicationUser
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(15)),
                    Roles = roles,
                    Cart = user.Cart
                };

            }



            // What about our errors?
            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(user.Password) :
                    error.Code.Contains("Email") ? nameof(user.Email) :
                    error.Code.Contains("UserName") ? nameof(user.UserName) :
                    "";
                ModelState.AddModelError(errorKey, error.Description);
            }



            if (ModelState.IsValid)
            {
                return user;
            }

            return BadRequest(new ValidationProblemDetails(ModelState));
        }



        [HttpPost("Login")]
        public async Task<ActionResult<ApplicationUser>> Login(ApplicationUser data)
        {

            var user = await userManager.FindByNameAsync(data.UserName);

            if (await userManager.CheckPasswordAsync(user, data.Password))
            {
                await signInManager.SignInAsync(user, null);

                return new ApplicationUser
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(15)),
                    Roles = user.Roles,
                    Cart = user.Cart
                };
            }
            if (user == null)
            {
                return Unauthorized();
            }

            return BadRequest();
        }
        //Update the user's Cart
[HttpPost("{userId}")]
public async Task<IActionResult> AddToCart(string userId, int productId)
{
    // Find the user and include their cart
// Find the user, include their cart, and also include the products associated with each cart item
var user = await userManager.Users.Include(u => u.Cart)
                                  .Include(u => u.Cart.CartItems)
                                  .ThenInclude(ci => ci.Product)
                                  .FirstOrDefaultAsync(u => u.Id == userId);


    if (user == null)
    {
        return NotFound("User not found");
    }

  // Fetch the product from the database
var product = await context.Products.FindAsync(productId);


    // Initialize the user's cart if it doesn't exist
    if (user.Cart == null)
    {
        user.Cart = new UsersCart();
        context.UsersCart.Add(user.Cart);  // Let EF know it's a new cart
    }

    // Check if the product is already in the user's cart
    var cartItem = user.Cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
    if (cartItem == null)
    {
        // If not, add a new cart item with quantity 1
        cartItem = new CartItem
        {
            Product = product,
            Quantity = 1
        };
        user.Cart.CartItems.Add(cartItem);
    }
    else
    {
        // If it is, increment the quantity
        cartItem.Quantity++;
    }

    // Save changes
    await context.SaveChangesAsync();

    return Ok(user);
}


        [Authorize(Policy = "create")]
        [HttpGet("me")]
        public async Task<ApplicationUser> GetUser(ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);
            //  await userManager.AddToRolesAsync(user, user.Roles);

            return new ApplicationUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Roles = await userManager.GetRolesAsync(user)
            };
        }
    }
}
