using Pluralsight.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pluralsight.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Itaian},
                new Restaurant{Id = 2, Name = "Cinammon Club", Location = "London", Cuisine = CuisineType.None},
                new Restaurant{Id = 3, Name = "La Costa", Location = "New York", Cuisine = CuisineType.Indian},
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in _restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return _restaurants.SingleOrDefault(r => r.Id == id);
        }

    }
}
