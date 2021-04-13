using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Esport.Data;
using Esport.Models;

namespace Esport.Pages.Competitions
{
    public class IndexModel : PageModel
    {
        private readonly Esport.Data.ApplicationDbContext _context;

        public IndexModel(Esport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Competition> Competition { get;set; }

        public async Task OnGetAsync()
        {
            Competition = await _context.Competition.ToListAsync();
        }
    }
}
