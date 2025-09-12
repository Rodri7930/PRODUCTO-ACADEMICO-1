using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PD1.Data;
using PD1.Models;

namespace PD1.Pages.Proveedores
{
    public class DeleteModel : PageModel
    {
        private readonly SistemaPD1Context _context;
        public DeleteModel(SistemaPD1Context context) => _context = context;

        [BindProperty]
        public Proveedor Proveedor { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Proveedor = await _context.Proveedores.FindAsync(id);
            if (Proveedor == null)
                return RedirectToPage("Index");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            try
            {
                _context.Proveedores.Remove(proveedor);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch
            {
                TempData["Error"] = "No se puede eliminar porque tiene productos asociados.";
                return RedirectToPage("./Index");
            }
        }
    }
}