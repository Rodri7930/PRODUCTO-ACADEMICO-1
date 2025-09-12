using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PD1.Data;
using PD1.Models;

namespace PD1.Pages.Categorias
{
    public class EditModel : PageModel
    {
        private readonly SistemaPD1Context _context;
        public EditModel(SistemaPD1Context context) => _context = context;

        [BindProperty]
        public Categoria Categoria { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Categoria = await _context.Categorias.FindAsync(id);
            if (Categoria == null)
                return RedirectToPage("Index");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            _context.Attach(Categoria).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Categorias.AnyAsync(e => e.CategoriaID == Categoria.CategoriaID))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToPage("Index");
        }
    }
}