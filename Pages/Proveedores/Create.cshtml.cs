using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PD1.Data;
using PD1.Models;

namespace PD1.Pages.Proveedores
{
    public class CreateModel : PageModel
    {
        private readonly SistemaPD1Context _context;
        public CreateModel(SistemaPD1Context context) => _context = context;

        [BindProperty]
        public Proveedor Proveedor { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            Proveedor.FechaRegistro = System.DateTime.Now;
            _context.Proveedores.Add(Proveedor);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}