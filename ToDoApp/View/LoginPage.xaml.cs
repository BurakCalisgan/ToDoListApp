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

namespace ToDoApp.View
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        private static IUserService _userService;

        public LoginPage()
        {
            InitializeComponent();
        }
        public LoginPage(IUserService userService)
        {
            InitializeComponent();
            if (_userService == null)
            {
                _userService = userService;
            }
            
        }

        #region Click Functions

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = _userService.GetByUserName(txtUserName.Text);

                if (user != null)
                {
                    if (user.Password == txtPassword.Password)
                    {
                        Application.Current.Properties["UserId"] = user.Id;

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("UserName or Password is incorrect !");
                    }
                }
                else
                {
                    MessageBox.Show("User not found !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred : " + ex.Message);
            }

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RegisterPage registerWindow = new RegisterPage();
                registerWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred : " + ex.Message);
            }
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
