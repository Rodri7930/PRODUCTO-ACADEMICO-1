using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PD1.Data;
using PD1.Models;

namespace PD1.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly SistemaPD1Context _context;
        public IndexModel(SistemaPD1Context context) => _context = context;

        public IList<Cliente> Clientes { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string searchString, int pageIndex = 1)
        {
            int pageSize = 10;
            var query = _context.Clientes.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(c => c.NombreCliente.Contains(searchString));
            }
            int total = await query.CountAsync();
            Clientes = await query
                .OrderBy(c => c.NombreCliente)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(total / (double)pageSize);
            CurrentFilter = searchString;
        }
    }
}