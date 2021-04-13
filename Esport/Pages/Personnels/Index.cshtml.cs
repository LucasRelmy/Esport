using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Esport.Data;
using Esport.Models;
using Microsoft.AspNetCore.Authorization;

namespace Esport.Pages.Shared.Personnels
{
    [Authorize(Roles = "personnel")]

    public class IndexModel : PageModel
    {
        private readonly Esport.Data.ApplicationDbContext _context;

        public IndexModel(Esport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Personnel> Personnel { get;set; }

        public async Task OnGetAsync()
        {
            Personnel = await _context.Personnel.ToListAsync();
        }
    }
}
