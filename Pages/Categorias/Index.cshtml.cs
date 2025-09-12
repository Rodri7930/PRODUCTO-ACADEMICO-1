using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PD1.Data;
using PD1.Models;

namespace PD1.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        private readonly SistemaPD1Context _context;
        public IndexModel(SistemaPD1Context context) => _context = context;

        public IList<Categoria> Categorias { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string searchString, int pageIndex = 1)
        {
            int pageSize = 10;
            var query = _context.Categorias.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(c => c.NombreCategoria.Contains(searchString));
            }
            int total = await query.CountAsync();
            Categorias = await query
                .OrderBy(c => c.NombreCategoria)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(total / (double)pageSize);
            CurrentFilter = searchString;
        }
    }
}