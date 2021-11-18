using ElectronicDiary.Entities;
using Microsoft.EntityFrameworkCore;
using Simplified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.ViewModels
{
    // Конекст данных для страницы Авторизации
    public partial class MainViewModel
    {
        private bool _isAuthorization;
        private RelayCommand _authorizationCommand;
        private User _currentUser;
        private string _errorAuthorizationErrorMessage = string.Empty;

        public bool IsAuthorization { get => _isAuthorization; private set => Set(ref _isAuthorization, value); }

        public User CurrentUser { get => _currentUser; private set => Set(ref _currentUser, value); }

        public RelayCommand AuthorizationCommand => _authorizationCommand ??= new RelayCommand<User>(AuthorizationExecute, AuthorizationCanExecute);

        public string ErrorAuthorizationErrorMessage { get => _errorAuthorizationErrorMessage; private set => Set(ref _errorAuthorizationErrorMessage, value); }

        private bool AuthorizationCanExecute(User user)
        {
            return !string.IsNullOrWhiteSpace(user.Login) &&
                !string.IsNullOrWhiteSpace(user.Password);
        }

        private void AuthorizationExecute(User user)
        {
            User dbuser = dbStudents.Users.Include(usr => usr.Role).FirstOrDefault(usr => usr.Login == user.Login && usr.Password == user.Password);
            if(dbuser == null)
            {
                ErrorAuthorizationErrorMessage = "Пользователя с таким паролем и логином нет.";
            }
            else
            {
                ErrorAuthorizationErrorMessage = string.Empty;
                CurrentUser = dbuser;

                switch (dbuser.Role.Title)
                {
                    case "Преподаватель":
                        ViewModeCommand.TryExecute(ViewMode.Teacher);
                        break;
                    case "Студент":
                        ViewModeCommand.TryExecute(ViewMode.Student);
                        break;
                }

            }
        }
    }

}
