using System;
using System.Collections.Generic;
using System.Linq;
using Pluralsight.Core;

namespace Pluralsight.Data
{
    public class InMemoryUserData : IUserData
    {
        List<User> _users;

        public InMemoryUserData()
        {
            _users = new List<User>()
            {
                new User{Id = 1, FirstName = "Karen", LastName = "Jones", Dob = "1/2/1989"},
                new User{Id = 2, FirstName = "Matt", LastName = "Smith", Dob = "23/5/19711"},
                new User{Id = 3, FirstName = "Louise", LastName = "Williams", Dob = "31/1/2000"},
            };
        }

        public IEnumerable<User> GetAll()
        {
            return from u in _users
                   orderby u.Id
                   select u;
        }
    }
}
