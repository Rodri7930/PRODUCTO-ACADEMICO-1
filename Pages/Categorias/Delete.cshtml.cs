using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PD1.Data;
using PD1.Models;

namespace PD1.Pages.Categorias
{
    public class DeleteModel : PageModel
    {
        private readonly SistemaPD1Context _context;
        public DeleteModel(SistemaPD1Context context) => _context = context;

        [BindProperty]
        public Categoria Categoria { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Categoria = await _context.Categorias.FindAsync(id);
            if (Categoria == null)
                return RedirectToPage("Index");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            try
            {
                _context.Categorias.Remove(categoria);
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