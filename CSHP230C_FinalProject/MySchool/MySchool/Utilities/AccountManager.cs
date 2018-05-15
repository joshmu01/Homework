using MySchool.Data.Interfaces;
using MySchool.Data.Repositories;
using MySchool.Entities.Models;
using MySchool.Entities.ViewModels;

namespace MySchool.Utilities
{
    public class AccountManager
    {
        private static UserRepository _userRepository;

        /// <summary>
        /// This constructor helps to setup dependency
        /// injection using the above field.
        /// </summary>
        /// <param name="userRepository"></param>
        public AccountManager(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// This checks the database for a User object with
        /// UserName and UserPassword values that match the
        /// input fields of the form. If one exists, then this
        /// returns a value of true, otherwise it's false.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public static bool IsUserValid(string userName, string userPassword)
        {
            bool isValid = false;
            UserModel userModel = _userRepository.GetUser(userName);
            if (userModel.UserId != null && 
                userModel.UserPassword.ToLower() == userPassword.ToLower())
            {
                isValid = true;
            }
            return isValid;
        }

        /// <summary>
        /// This checks the database for a User object with
        /// a UserName value that matches the input field of
        /// the form. If one exists, then this returns a value
        /// of true, otherwise it's false.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool IsUserNameAvailable(string userName)
        {
            bool isAvailable = true;
            UserModel userModel = _userRepository.GetUser(userName);
            if (userModel.UserId != null)
            {
                isAvailable = false;
            }
            return isAvailable;
        }

        /// <summary>
        /// This creates a new UserModel object and passes it
        /// to the UserRepository where it's used to create a new
        /// User object to be added to the database. If it's successfully
        /// added, this returns a value of true, otherwise it's false.
        /// </summary>
        /// <param name="newUserViewModel"></param>
        /// <returns></returns>
        public static bool AddNewUser(NewOrUpdateProfileViewModel newUserViewModel)
        {
            UserModel userToAdd = new UserModel();
            userToAdd.UserName = newUserViewModel.Name;
            userToAdd.UserEmail = newUserViewModel.Email;
            userToAdd.UserPassword = newUserViewModel.Password;
            return _userRepository.AddUser(userToAdd);
        }

    }
}