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
    public class ListModel : PageModel
    {
        private readonly IUserData _data;
        public IEnumerable<User> Users { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IUserData data)
        {
            _data = data;
        }

        public void OnGet()
        {
            Users = _data.GetUserByName(SearchTerm);
        }
    }
}