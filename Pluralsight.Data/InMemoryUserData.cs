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

        public IEnumerable<User> GetByFirstName(string name = null)
        {
            return from u in _users
                   where string.IsNullOrEmpty(name) || u.FirstName.StartsWith(name)
                   orderby u.Id
                   select u;
        }

        public User GetById(int id)
        {
            return _users.SingleOrDefault(u => u.Id == id);
        }

        public User Update(User updatedUser)
        {
            var user = _users.SingleOrDefault(u => u.Id == updatedUser.Id);
            if(user != null)
            {
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Dob = updatedUser.Dob;
            }

            return user;
        }

        public int Commit()
        {
            return 1;
        }

        public User Add(User newUser)
        {
            newUser.Id = _users.Max(u => u.Id) + 1;
            _users.Add(newUser);
            return newUser;
        }

        public User Delete(int id)
        {
            var user = _users.SingleOrDefault(u => u.Id == id);
            if(user != null)
            {
                _users.Remove(user);
            }

            return user;
        }
    }
}
