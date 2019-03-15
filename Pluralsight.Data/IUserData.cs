using Pluralsight.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.Data
{
    public interface IUserData
    {
        IEnumerable<User> GetUserByName(string name);
        User GetById(int id);
        User Update(User updatedUser);
        User Add(User newUser);
        int Commit();
    }
}
