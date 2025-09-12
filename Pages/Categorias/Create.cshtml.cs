using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PD1.Data;
using PD1.Models;

namespace PD1.Pages.Categorias
{
    public class CreateModel : PageModel
    {
        private readonly SistemaPD1Context _context;
        public CreateModel(SistemaPD1Context context) => _context = context;

        [BindProperty]
        public Categoria Categoria { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            Categoria.FechaCreacion = System.DateTime.Now;
            _context.Categorias.Add(Categoria);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}