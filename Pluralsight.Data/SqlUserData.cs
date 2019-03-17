using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pluralsight.Core;

namespace Pluralsight.Data
{
    public class SqlUserData : IUserData
    {
        private readonly PluralsightDbContext _db;

        public SqlUserData(PluralsightDbContext db)
        {
            _db = db;
        }

        public User Add(User newUser)
        {
            _db.Add(newUser);
            return newUser;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public User Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _db.Users.Remove(user);
            }
            return user;
        }

        public User GetById(int id)
        {
            return _db.Users.Find(id);
        }

        public IEnumerable<User> GetByFirstName(string name)
        {
            var query = from u in _db.Users
                        where u.FirstName.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby u.Id
                        select u;
            return query;
        }

        public User Update(User updatedUser)
        {
            var entity = _db.Users.Attach(updatedUser);
            entity.State = EntityState.Modified;
            return updatedUser;
        }
    }
}
