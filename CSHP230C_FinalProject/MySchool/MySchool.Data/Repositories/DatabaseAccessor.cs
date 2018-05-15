using MySchool.Data.Database;

namespace MySchool.Data.Repositories
{
    public class DatabaseAccessor
    {
        static DatabaseAccessor()
        {
            Instance = new SchoolDBEntities();
            Instance.Database.Connection.Open();
        }
        public static SchoolDBEntities Instance { get; }
    }
}