using ElectronicDiary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElectronicDiary.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }
        
        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_Login.Text) || string.IsNullOrEmpty(PasswordBox_Password.Password))
            {
                MessageBox.Show("Ввведите логин и пароль");
                return;
            }
            else
            {
                //Example
                using (var db = new DB_Context())
                {
                    var user = db.Users
                        .AsNoTracking()
                        .FirstOrDefault(u => u.Login == TextBox_Login.Text && u.Password == PasswordBox_Password.Password);
                    if (user == null)
                    {
                        MessageBox.Show("Пользователь не найден");
                    }
                    else
                    {
                        ClassForData.UserID = user.ID;

                        switch (user.ID_Role)
                        {
                            case 1:
                                var teacherID = db.Teachers.AsNoTracking().FirstOrDefault(it => it.ID_User == ClassForData.UserID);
                                ClassForData.TeacherID = teacherID.ID;
                                NavigationService.Navigate(new TeacherPage());
                                break;
                            case 2:
                                var group = db.Student.AsNoTracking().FirstOrDefault(it => it.ID_User == ClassForData.UserID);
                                ClassForData.GroupID = group.ID_Group;
                                NavigationService.Navigate(new StudentPage());
                                break;
                        }
                    }
                }
            }
        }
    }
}
