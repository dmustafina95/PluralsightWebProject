using Pluralsight.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.Data
{
    public interface IUserData
    {
        IEnumerable<User> GetByFirstName(string name);
        User GetById(int id);
        User Update(User updatedUser);
        User Add(User newUser);
        User Delete(int id);
        int GetUserCount();
        int Commit();
    }
}
