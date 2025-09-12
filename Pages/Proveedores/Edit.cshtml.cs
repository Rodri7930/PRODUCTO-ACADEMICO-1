using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PD1.Data;
using PD1.Models;

namespace PD1.Pages.Proveedores
{
    public class EditModel : PageModel
    {
        private readonly SistemaPD1Context _context;
        public EditModel(SistemaPD1Context context) => _context = context;

        [BindProperty]
        public Proveedor Proveedor { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Proveedor = await _context.Proveedores.FindAsync(id);
            if (Proveedor == null)
                return RedirectToPage("Index");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Attach(Proveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Proveedores.AnyAsync(e => e.ProveedorID == Proveedor.ProveedorID))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToPage("Index");
        }
    }
}