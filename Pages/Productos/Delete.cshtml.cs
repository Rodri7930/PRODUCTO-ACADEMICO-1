using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PD1.Data;
using PD1.Models;

namespace PD1.Pages.Productos
{
    public class DeleteModel : PageModel
    {
        private readonly SistemaPD1Context _context;
        public DeleteModel(SistemaPD1Context context) => _context = context;

        [BindProperty]
        public Producto Producto { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.ProductoID == id);
            if (Producto == null)
                return RedirectToPage("Index");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}