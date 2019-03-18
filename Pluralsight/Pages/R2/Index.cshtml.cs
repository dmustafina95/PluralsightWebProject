using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pluralsight.Core;
using Pluralsight.Data;

namespace Pluralsight.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly Pluralsight.Data.PluralsightDbContext _context;

        public IndexModel(Pluralsight.Data.PluralsightDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
