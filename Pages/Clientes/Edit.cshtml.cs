using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PD1.Data;
using PD1.Models;

namespace PD1.Pages.Clientes
{
    public class EditModel : PageModel
    {
        private readonly SistemaPD1Context _context;
        public EditModel(SistemaPD1Context context) => _context = context;

        [BindProperty]
        public Cliente Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Cliente = await _context.Clientes.FindAsync(id);
            if (Cliente == null)
                return RedirectToPage("Index");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            var clienteDb = await _context.Clientes.FindAsync(Cliente.ClienteID);
            if (clienteDb == null)
                return RedirectToPage("Index");
            clienteDb.NombreCliente = Cliente.NombreCliente;
            clienteDb.Email = Cliente.Email;
            clienteDb.Telefono = Cliente.Telefono;
            clienteDb.Direccion = Cliente.Direccion;
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}