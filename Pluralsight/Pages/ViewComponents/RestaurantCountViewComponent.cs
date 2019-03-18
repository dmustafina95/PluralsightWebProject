using Microsoft.AspNetCore.Mvc;
using Pluralsight.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pluralsight.Pages.ViewComponents
{
    public class RestaurantCountViewComponent: ViewComponent
    {
        private readonly IRestaurantData _data;

        public RestaurantCountViewComponent(IRestaurantData data)
        {
            _data = data;
        }

        public IViewComponentResult Invoke()
        {
            var count = _data.GetRestaurantCount();
            return View(count);
        }
    }
}
