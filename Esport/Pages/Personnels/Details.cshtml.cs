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

    public class DetailsModel : PageModel
    {
        private readonly Esport.Data.ApplicationDbContext _context;

        public DetailsModel(Esport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Personnel Personnel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Personnel = await _context.Personnel.FirstOrDefaultAsync(m => m.ID == id);

            if (Personnel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
