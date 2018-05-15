using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningCenter.Database;

namespace TheLearningCenter.Interfaces
{
    interface IRepository
    {
        IEnumerable<User> GetUsers { get; }
        IEnumerable<UserClass> GetUserClasses { get; }
        IEnumerable<Class> GetClasses { get; }
    }
}
