using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PD1.Data;
using PD1.Models;
using System.Linq;

namespace PD1.Pages.Productos
{
    public class CreateModel : PageModel
    {
        private readonly SistemaPD1Context _context;
        public CreateModel(SistemaPD1Context context) => _context = context;

        [BindProperty]
        public Producto Producto { get; set; }
        public SelectList Categorias { get; set; }
        public SelectList Proveedores { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Categorias = new SelectList(await _context.Categorias.ToListAsync(), "CategoriaID", "NombreCategoria");
            Proveedores = new SelectList(await _context.Proveedores.ToListAsync(), "ProveedorID", "NombreProveedor");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Categorias = new SelectList(await _context.Categorias.ToListAsync(), "CategoriaID", "NombreCategoria");
                Proveedores = new SelectList(await _context.Proveedores.ToListAsync(), "ProveedorID", "NombreProveedor");
                return Page();
            }
            _context.Productos.Add(Producto);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}