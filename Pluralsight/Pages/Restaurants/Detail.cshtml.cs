using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pluralsight.Core;
using Pluralsight.Data;

namespace Pluralsight.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData _data;

        public Restaurant Restaurant { get; set; }
        [TempData]
        public string Message { get; set; }

        public DetailModel(IRestaurantData data)
        {
            _data = data;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _data.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}