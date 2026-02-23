using EncuestaRazorPage.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EncuestaRazorPage.Pages
{
    public class CustomGridModel : PageModel
    {
        public List<Product> Products { get; set; } = new List<Product>
        {
            new Product { Id = 1, Name = "Product A", Price = 10.99m, Description = "Description for Product A" },
            new Product { Id = 2, Name = "Product B", Price = 15.49m, Description = "Description for Product B" },
            new Product { Id = 3, Name = "Product C", Price = 7.99m, Description = "Description for Product C" }
        };
        
        public void OnGet()
        {
        }
    }
}
