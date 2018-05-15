using System.Collections.Generic;
using System.Linq;
using MySchool.Data.Database;
using MySchool.Data.Interfaces;
using MySchool.Entities.Models;

namespace MySchool.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetUsers => DatabaseAccessor.Instance.Users;

        /// <summary>
        /// This creates a UserModel object with data
        /// gathered from a data context User object.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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
                        UserIsAdmin = u.UserIsAdmin
                    }).First();
        }

        /// <summary>
        /// This reates a UserModel object with data
        /// gathered from a data context User object.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>UserModel</returns>
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
                        UserIsAdmin = u.UserIsAdmin
                    }).First();
        }

        /// <summary>
        /// This creates a List of UserModel objects
        /// that are gathered using the GetUser method.
        /// </summary>
        /// <returns></returns>
        public List<UserModel> ListUsers()
        {
            return (from u in GetUsers
                    select GetUser(u.UserID)).ToList();
        }

        /// <summary>
        /// This creates a List of UserModel objects
        /// that are gathered using the GetUser method,
        /// which are specific to a particular Class obejct.
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public List<UserModel> ListClassUsers(int classId)
        {
            return (from u in GetUsers
                    from c in u.Classes
                    where c.ClassID == classId
                    select GetUser(u.UserID)).ToList();
        }

        /// <summary>
        /// This adds a new User object to the database.
        /// </summary>
        /// <param name="userToAdd"></param>
        /// <returns></returns>
        public bool AddUser(UserModel userToAdd)
        {
            DatabaseAccessor.Instance.Users.Add(new User
            {
                UserName = userToAdd.UserName,
                UserEmail = userToAdd.UserEmail,
                UserPassword = userToAdd.UserPassword,
                UserIsAdmin = userToAdd.UserIsAdmin
            });
            return DatabaseAccessor.Instance.SaveChanges() > 0;
        }

        /// <summary>
        /// This removes an existing User object from the database.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool RemoveUser(int userId)
        {
            var userToRemove = DatabaseAccessor.Instance.Users.Where(t => t.UserID == userId);
            if (!userToRemove.Any())
            {
                return false;
            }
            DatabaseAccessor.Instance.Users.Remove(userToRemove.First());
            DatabaseAccessor.Instance.SaveChanges();
            return true;
        }

        /// <summary>
        /// This updates the fields of an existing User object
        /// in the database, but it doesn't update the User's
        /// List of Classes.
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public bool UpdateUser(UserModel userModel)
        {
            var users = DatabaseAccessor.Instance.Users.Where(t => t.UserID == userModel.UserId);
            if (!users.Any())
            {
                return false;
            }
            var userToUpdate = users.First();
            userToUpdate.UserName = userModel.UserName;
            userToUpdate.UserEmail = userModel.UserEmail;
            userToUpdate.UserPassword = userModel.UserPassword;
            userToUpdate.UserIsAdmin = userModel.UserIsAdmin;
            return DatabaseAccessor.Instance.SaveChanges() > 0;
        }

        /// <summary>
        /// This adds a Class to the User's List of Classes.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        public bool AddUserClass(int userId, int classId)
        {
            var users = DatabaseAccessor.Instance.Users.Where(t => t.UserID == userId);
            var classes = DatabaseAccessor.Instance.Classes.Where(t => t.ClassID == classId);
            if (!users.Any() || !classes.Any())
            {
                return false;
            }
            var userToUpdate = users.First();
            var classToAdd = classes.First();
            userToUpdate.Classes.Add(classToAdd);
            return DatabaseAccessor.Instance.SaveChanges() > 0;
        }
    }
}