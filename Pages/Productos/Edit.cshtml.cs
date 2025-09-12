using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PD1.Data;
using PD1.Models;

namespace PD1.Pages.Productos
{
    public class EditModel : PageModel
    {
        private readonly SistemaPD1Context _context;
        public EditModel(SistemaPD1Context context) => _context = context;

        [BindProperty]
        public Producto Producto { get; set; }
        public SelectList Categorias { get; set; }
        public SelectList Proveedores { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Producto = await _context.Productos.FindAsync(id);
            if (Producto == null)
                return RedirectToPage("Index");
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
            var productoDb = await _context.Productos.FindAsync(Producto.ProductoID);
            if (productoDb == null)
                return RedirectToPage("Index");
            productoDb.NombreProducto = Producto.NombreProducto;
            productoDb.Descripcion = Producto.Descripcion;
            productoDb.Precio = Producto.Precio;
            productoDb.Stock = Producto.Stock;
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}