using System.Collections.Generic;
using System.Linq;
using MySchool.Data.Database;
using MySchool.Data.Interfaces;
using MySchool.Entities.Models;

namespace MySchool.Data.Repositories
{
    public class ClassRepository : IClassRepository
    {
        public IEnumerable<Class> GetClasses => DatabaseAccessor.Instance.Classes;

        /// <summary>
        /// This creates a ClassModel object with data
        /// gathered from a data context Class object.
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public ClassModel GetClass(int classId)
        {
            return (from c in GetClasses
                    where c.ClassID == classId
                    select new ClassModel
                    {
                        ClassId = c.ClassID,
                        ClassName = c.ClassName,
                        ClassDescription = c.ClassDescription,
                        ClassPrice = c.ClassPrice,
                    }).First();
        }

        /// <summary>
        /// This creates a ClassModel object with data
        /// gathered from a data context Class object.
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public ClassModel GetClass(string className)
        {
            return (from c in GetClasses
                    where c.ClassName.ToLower() == className.ToLower()
                    select new ClassModel
                    {
                        ClassId = c.ClassID,
                        ClassName = c.ClassName,
                        ClassDescription = c.ClassDescription,
                        ClassPrice = c.ClassPrice
                    }).First();
        }

        /// <summary>
        /// This creates a List of ClassModel objects
        /// that are gathered using the GetClass method.
        /// </summary>
        /// <returns></returns>
        public List<ClassModel> ListClasses()
        {
            return (from c in GetClasses
                    select GetClass(c.ClassID)).ToList();
        }

        /// <summary>
        /// This creates a List of ClassModel objects
        /// that are gathered using the GetClass method,
        /// which are specific to a particular User object.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ClassModel> ListUserClasses(int userId)
        {
            return (from c in GetClasses
                    from u in c.Users
                    where u.UserID == userId
                    select GetClass(c.ClassID)).ToList();
        }

        /// <summary>
        /// This adds a new Class object to the database.
        /// </summary>
        /// <param name="classToAdd"></param>
        /// <returns></returns>
        public bool AddClass(ClassModel classToAdd)
        {
            DatabaseAccessor.Instance.Classes.Add(new Class
            {
                ClassName = classToAdd.ClassName,
                ClassDescription = classToAdd.ClassDescription,
                ClassPrice = classToAdd.ClassPrice
            });
            return DatabaseAccessor.Instance.SaveChanges() > 0;
        }

        /// <summary>
        /// This removes an existing Class object from the database.
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public bool RemoveClass(int classId)
        {
            var classToRemove = DatabaseAccessor.Instance.Classes.Where(t => t.ClassID == classId);
            if (!classToRemove.Any())
            {
                return false;
            }
            DatabaseAccessor.Instance.Classes.Remove(classToRemove.First());
            return DatabaseAccessor.Instance.SaveChanges() > 0;
        }

        /// <summary>
        /// This updates the fields of an existing Class object
        /// in the database, but it doesn't update the Class's
        /// List of Users.
        /// </summary>
        /// <param name="classModel"></param>
        /// <returns></returns>
        public bool UpdateClass(ClassModel classModel)
        {
            var classes = DatabaseAccessor.Instance.Classes.Where(t => t.ClassID == classModel.ClassId);
            if (!classes.Any())
            {
                return false;
            }
            var classToUpdate = classes.First();
            classToUpdate.ClassName = classModel.ClassName;
            classToUpdate.ClassDescription = classModel.ClassDescription;
            classToUpdate.ClassPrice = classModel.ClassPrice;
            return DatabaseAccessor.Instance.SaveChanges() > 0;
        }

        /// <summary>
        /// This adds a User to the Class's List of Users.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        public bool AddClassUser(int userId, int classId)
        {
            var classes = DatabaseAccessor.Instance.Classes.Where(t => t.ClassID == classId);
            var users = DatabaseAccessor.Instance.Users.Where(t => t.UserID == userId);
            if (!classes.Any() || !users.Any())
            {
                return false;
            }
            var classToUpdate = classes.First();
            var userToAdd = users.First();
            classToUpdate.Users.Add(userToAdd);
            return DatabaseAccessor.Instance.SaveChanges() > 0;
        }
    }
}