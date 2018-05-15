using System.Collections.Generic;
using MySchool.Data.Database;
using MySchool.Entities.Models;

namespace MySchool.Data.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers { get; }
        UserModel GetUser(int userId);
        UserModel GetUser(string userName);
        List<UserModel> ListUsers();
        List<UserModel> ListClassUsers(int classId);
        bool AddUser(UserModel userToAdd);
        bool RemoveUser(int userId);
        bool UpdateUser(UserModel userModel);
        bool AddUserClass(int userId, int classId);
    }
}
