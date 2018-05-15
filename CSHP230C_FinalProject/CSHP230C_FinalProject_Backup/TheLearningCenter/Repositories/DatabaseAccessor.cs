using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheLearningCenter.Database;

namespace TheLearningCenter.Repositories
{
    public class DatabaseAccessor
    {
        static DatabaseAccessor()
        {
            Instance = new SchoolDBEntities();
            Instance.Database.Connection.Open();
        }

        public static SchoolDBEntities Instance { get;}
    }
}