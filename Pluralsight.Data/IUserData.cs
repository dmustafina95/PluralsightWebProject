using Pluralsight.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pluralsight.Data
{
    public interface IUserData
    {
        IEnumerable<User> GetAll();
    }
}
