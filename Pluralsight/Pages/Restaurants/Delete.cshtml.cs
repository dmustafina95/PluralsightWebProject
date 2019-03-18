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
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData _data;
        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData data)
        {
            _data = data;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _data.GetById(restaurantId);
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = _data.Delete(restaurantId);
            _data.Commit();

            if(restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{restaurant.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}