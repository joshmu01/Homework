using System.Collections.Generic;
using MySchool.Data.Database;
using MySchool.Entities.Models;

namespace MySchool.Data.Interfaces
{
    public interface IClassRepository
    {
        IEnumerable<Class> GetClasses { get; }
        ClassModel GetClass(int classId);
        ClassModel GetClass(string className);
        List<ClassModel> ListClasses();
        List<ClassModel> ListUserClasses(int userId);
        bool AddClass(ClassModel classToAdd);
        bool RemoveClass(int classId);
        bool UpdateClass(ClassModel classModel);
        bool AddClassUser(int userId, int classId);
    }
}
