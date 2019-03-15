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
    public class EditModel : PageModel
    {
        private readonly IUserData _data;
        [BindProperty]
        public User User { get; set; }

        public EditModel(IUserData data)
        {
            _data = data;
        }

        public IActionResult OnGet(int? userId)
        {
            if(userId.HasValue)
            {
                User = _data.GetById(userId.Value);
            }
            else
            {
                User = new User();
            }

            if (User == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
                
            }
            if (User.Id > 0)
            {
                _data.Update(User);
            }
            else
            {
                _data.Add(User);
            }
            _data.Commit();

            TempData["Message"] = "User saved!";
            return RedirectToPage("./Detail", new { userId = User.Id });
        }
    }
}