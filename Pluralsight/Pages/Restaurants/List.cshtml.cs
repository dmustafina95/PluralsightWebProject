using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Pluralsight.Core;
using Pluralsight.Data;

namespace Pluralsight.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData _data;
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IRestaurantData data)
        {
            _data = data;
        }

        public void OnGet()
        {
            Restaurants = _data.GetRestaurantsByName(SearchTerm);
        }
    }
}