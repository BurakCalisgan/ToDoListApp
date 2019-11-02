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
using ToDoApp.Business.Abstract;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.DataAccess.Concrete.EfCore;
using ToDoApp.Entities;

namespace ToDoApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUserService _userService;
        public MainWindow()
        {
            InitializeComponent();
            string a = Application.Current.Properties["UserId"].ToString();
        }
        public MainWindow(IUserService userService)
        {
            _userService = userService;
        }
    }
}
