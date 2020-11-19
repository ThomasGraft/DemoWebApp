using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoWebApp.Pages
{
    public class EditorModel : PageModel
    {
        private DataContext context;

        public EditorModel(DataContext ctx)
        {
            context = ctx;
        }

        public Product Product { get; set; }

        public async Task OnGetAsync(long id)
        {
            Product = await context.Products.FindAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(long id, decimal price)
        {
            Product p = await context.Products.FindAsync(id);
            p.Price = price;
            await context.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
