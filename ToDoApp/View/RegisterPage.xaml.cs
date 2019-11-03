using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToDoApp.Business.Abstract;
using ToDoApp.Entities;

namespace ToDoApp.View
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        private static IUserService _userService;

        public RegisterPage()
        {
            InitializeComponent();
        }

        public RegisterPage(IUserService userService)
        {
            InitializeComponent();
            if (_userService == null)
            {
                _userService = userService;
            }
        }

        #region Click Functions

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtFullName.Text) || !string.IsNullOrEmpty(txtUserName.Text) || !string.IsNullOrEmpty(txtPassword.Password))
                {
                    var newUser = new User()
                    {
                        FullName = txtFullName.Text,
                        UserName = txtUserName.Text,
                        Password = txtPassword.Password

                    };

                    _userService.Create(newUser);
                    RedirectToLogin();

                }
                else
                {
                    MessageBox.Show("User information must be filled !");
                }
               


            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred : " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            RedirectToLogin();
        }

        public void RedirectToLogin()
        {
            LoginPage loginWindow = new LoginPage();
            loginWindow.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //protected override void OnClosed(EventArgs e)
        //{
        //    base.OnClosed(e);

        //    Application.Current.Shutdown();
        //}

        #endregion Click Functions

    }
}
