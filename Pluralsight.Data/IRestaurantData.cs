using Pluralsight.Core;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
    }
}
