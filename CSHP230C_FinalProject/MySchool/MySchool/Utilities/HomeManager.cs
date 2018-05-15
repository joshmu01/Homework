using System.Collections.Generic;
using MySchool.Data.Interfaces;
using MySchool.Data.Repositories;
using MySchool.Entities.Models;
using MySchool.Entities.ViewModels;

namespace MySchool.Utilities
{
    public class HomeManager
    {
        private readonly UserRepository _userRepository;
        private readonly ClassRepository _classRepository;

        /// <summary>
        /// This constructor helps to setup dependency
        /// injection using the above fields.
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="classRepository"></param>
        public HomeManager(UserRepository userRepository, ClassRepository classRepository)
        {
            _userRepository = userRepository;
            _classRepository = classRepository;
        }

        /// <summary>
        /// This creates a List of ListClassesViewModel objects
        /// to be displayed in the AllClasses and RegisterClasses view.
        /// </summary>
        /// <returns name="displayModel"></returns>
        public List<ListClassesViewModel> DisplayAllClasses()
        {
            List<ClassModel> myClasses = _classRepository.ListClasses();
            List<ListClassesViewModel> displayModel = new List<ListClassesViewModel>();

            foreach (var c in myClasses)
            {
                ListClassesViewModel myClassesViewModel = new ListClassesViewModel();
                myClassesViewModel.ClassName = c.ClassName;
                myClassesViewModel.ClassDescription = c.ClassDescription;
                myClassesViewModel.ClassPrice = c.ClassPrice;
                displayModel.Add(myClassesViewModel);
            }

            return displayModel;
        }

        /// <summary>
        /// This creates a List of ListClassesViewModel objects
        /// to be displayed in the MyClasses view.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns name="displayModel"></returns>
        public List<ListClassesViewModel> DisplayMyClasses(string userName)
        {
            UserModel currentUser = _userRepository.GetUser(userName);
            List<ClassModel> myClasses = new List<ClassModel>();
            List<ListClassesViewModel> displayModel = new List<ListClassesViewModel>();

            if (currentUser.UserId != null)
            {
                myClasses = _classRepository.ListUserClasses((int)currentUser.UserId);
            }

            foreach (var c in myClasses)
            {
                ListClassesViewModel myClassesViewModel = new ListClassesViewModel();
                myClassesViewModel.ClassName = c.ClassName;
                myClassesViewModel.ClassDescription = c.ClassDescription;
                myClassesViewModel.ClassPrice = c.ClassPrice;
                displayModel.Add(myClassesViewModel);
            }

            return displayModel;
        }

        /// <summary>
        /// This adds a Class to a User's Collection of Classes.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="selectedClass"></param>
        /// <returns name="isClassAdded"></returns>
        public bool AddNewClass(string userName, ListClassesViewModel selectedClass)
        {
            bool isClassAdded = false;
            UserModel currentUser = _userRepository.GetUser(userName);
            ClassModel classToAdd = _classRepository.GetClass(selectedClass.ClassName);

            if (currentUser.UserId != null && classToAdd.ClassId != null)
            {
                List<ClassModel> currentUsersClasses = _classRepository.ListUserClasses((int)currentUser.UserId);
                if (!currentUsersClasses.Contains(classToAdd))
                {
                    isClassAdded =  _userRepository.AddUserClass((int)currentUser.UserId, (int)classToAdd.ClassId);
                }
            }
            return isClassAdded;
        }
    }
}