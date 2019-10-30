using System;
using System.Collections.Generic;
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
using ToDoApp.DataAccess.Abstract;
using ToDoApp.Entities;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUserDal _userDal;
        public MainWindow(IUserDal userDal)
        {
            _userDal = userDal;
            InitializeComponent();

            User user = new User();
            user.FullName = "Kadir Erceylan";
            user.UserName = "Kadir";
            user.Password = "1234567";
            _userDal.Create(user);

            var userList = _userDal.GetAll();

        }
    }
}
