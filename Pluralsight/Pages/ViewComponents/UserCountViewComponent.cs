using Microsoft.AspNetCore.Mvc;
using Pluralsight.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pluralsight.Pages.ViewComponents
{
    public class UserCountViewComponent: ViewComponent
    {
        private readonly IUserData _data;

        public UserCountViewComponent(IUserData data)
        {
            _data = data;
        }

        public IViewComponentResult Invoke()
        {
            var count = _data.GetUserCount();

            return View(count);
        }
    }
}
