using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pluralsight.Core;
using Pluralsight.Data;

namespace Pluralsight.Pages.Users
{
    public class DetailModel : PageModel
    {
        private readonly IUserData _data;
        public User User { get; set; }
        [TempData]
        public string Message { get; set; }

        public DetailModel(IUserData data)
        {
            _data = data;
        }

        public IActionResult OnGet(int userId)
        {
            User = _data.GetById(userId);
            if(User == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}