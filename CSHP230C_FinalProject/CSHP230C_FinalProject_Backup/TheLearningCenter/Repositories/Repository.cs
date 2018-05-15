using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheLearningCenter.Database;
using TheLearningCenter.Interfaces;
using TheLearningCenter.Models;
using static TheLearningCenter.Repositories.DatabaseAccessor;

namespace TheLearningCenter.Repositories
{
    public class Repository : IRepository
    {
        public IEnumerable<User> GetUsers => Instance.Users;
        public IEnumerable<UserClass> GetUserClasses => Instance.UserClasses;
        public IEnumerable<Class> GetClasses => Instance.Classes;

        public UserModel GetUser(int userId)
        {
            return (from u in GetUsers
                    where u.UserID == userId
                    select new UserModel
                    {
                        UserId = u.UserID,
                        UserName = u.UserName,
                        UserEmail = u.UserEmail,
                        UserPassword = u.UserPassword,
                        UserIsAdmin = u.UserIsAdmin,
                        UserClasses = GetUserClassSchedule(u.UserName)
                    }).First();
        }

        public UserModel GetUser(string userName)
        {
            return (from u in GetUsers
                    where u.UserName.ToLower() == userName.ToLower()
                    select new UserModel
                    {
                        UserId = u.UserID,
                        UserName = u.UserName,
                        UserEmail = u.UserEmail,
                        UserPassword = u.UserPassword,
                        UserIsAdmin = u.UserIsAdmin,
                        UserClasses = GetUserClassSchedule(userName)
                    }).First();
        }

        public List<UserModel> GetUserList()
        {
            return (from u in GetUsers
                    select GetUser(u.UserID)).ToList();
        }

        public ClassModel GetClass(int classId)
        {
            return (from c in GetClasses
                    where c.ClassID == classId
                    select new ClassModel
                    {
                        ClassId = c.ClassID,
                        ClassName = c.ClassName,
                        ClassDescription = c.ClassDescription,
                        ClassPrice = c.ClassPrice
                    }).First();
        }

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

        public List<ClassModel> GetClassList()
        {
            return (from c in GetClasses
                    select GetClass(c.ClassID)).ToList();
        }

        public List<ClassModel> GetUserClassSchedule(string userName)
        {
            return (from u in GetUsers
                    from uc in u.UserClasses
                    where u.UserName.ToLower() == userName.ToLower()
                    select GetClass(uc.ClassID)).ToList();
        }

        public UserModel CreateUserModel(NewUserModel model)
        {
            return new UserModel
            {
                UserName = model.Name,
                UserEmail = model.Email,
                UserPassword = model.Password,
                UserIsAdmin = false
            };
        }

        public List<UserModel> GetClassAttendees(string className)
        {
            return (from c in GetClasses
                    from uc in c.UserClasses
                    where c.ClassName.ToLower() == className.ToLower()
                    select GetUser(uc.UserID)).ToList();
        }

        public bool AddUser(UserModel userToAdd)
        {
            Instance.Users.Add(new User
            {
                UserName = userToAdd.UserName,
                UserEmail = userToAdd.UserEmail,
                UserPassword = userToAdd.UserPassword,
                UserIsAdmin = userToAdd.UserIsAdmin
            });
            return Instance.SaveChanges() > 0;
        }

        public bool AddUserClass(UserModel currentUser, ClassModel classToAdd)
        {

            var u = Instance.Users.SingleOrDefault(t => t.UserID == currentUser.UserId);
            var c = Instance.Classes.SingleOrDefault(t => t.ClassID == classToAdd.ClassId);

            if (u != null && c != null)
            {
                var uc = new UserClass { UserID = u.UserID, ClassID = c.ClassID };
                Instance.UserClasses.Add(uc);
                u.UserClasses.Add(uc);
                c.UserClasses.Add(uc);
            }
            return Instance.SaveChanges() > 0;
        }

        public static bool AddClass(ClassModel classToAdd)
        {
            Instance.Classes.Add(new Class
            {


                ClassName = classToAdd.ClassName,
                ClassDescription = classToAdd.ClassDescription,
                ClassPrice = classToAdd.ClassPrice
            });
            return Instance.SaveChanges() > 0;
        }

        public Boolean UserExists(string userName, string password)
        {
            return GetUsers.Any(t => t.UserName.ToLower() == userName.ToLower()
                                       && t.UserPassword.ToLower() == password.ToLower());
        }

        public Boolean UserNameExists(string userName)
        {
            return GetUsers.Any(t => t.UserName.ToLower() == userName.ToLower());
        }
    }
}