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
    public class DeleteModel : PageModel
    {
        private readonly IUserData _data;

        public User User { get; set; }

        public DeleteModel(IUserData data)
        {
            this._data = data;
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

        public IActionResult OnPost(int userId)
        {
            var user = _data.Delete(userId);
            _data.Commit();
            if(user == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{user.FirstName} {user.LastName} deleted";
            return RedirectToPage("./List");
        }
    }
}