using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToDoApp.Business.Abstract;
using ToDoApp.Entities;

namespace ToDoApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static IUserService _userService;
        private static IToDoListService _toDoListService;
        public int userId;
        public MainWindow()
        {
            InitializeComponent();

            userId = Convert.ToInt32(Application.Current.Properties["UserId"]);

            if (userId != 0)
            {
                FillToDoListMenu(userId);
                FillUserInfo();
            }

        }
        public MainWindow(IUserService userService, IToDoListService toDoListService)
        {
            _userService = userService;
            _toDoListService = toDoListService;
        }

        #region Fiil Functions
        public void FillToDoListMenu(int userId)
        {
            ToDoListMenu.ItemsSource = _toDoListService.GetToDoListByUserId(userId);
        }

        public void FillUserInfo()
        {
            User userInfo = _userService.GetById(userId);
            txtUserFullName.Text = userInfo.FullName;
        }


        #endregion Fiil Functions

        #region Event Functions


        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ToDoListMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int index = ToDoListMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    MessageBox.Show("test");
                    break;
                case 1:
                    MessageBox.Show("test2");
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }

        #region Delete ToDoList
        private void ToDoListMenu_Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = sender as Button;
                ToDoList toDoList = button.DataContext as ToDoList;

                if (toDoList != null)
                {
                    _toDoListService.Delete(toDoList);
                    FillToDoListMenu(userId);
                    MessageBox.Show("ToDo List has been deleted successfully.");
                }
                else
                {
                    MessageBox.Show("ToDo List has not been selected.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred : " + ex.Message);
            }

        }
        #endregion Delete ToDoList

        #region Edit ToDoList
        ToDoList willBeUpdatedToDo;
        private void ToDoListMenu_Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            popupToDoEdit.IsOpen = true;
            Button button = sender as Button;
            willBeUpdatedToDo = button.DataContext as ToDoList;
            txtToDoEditName.Text = willBeUpdatedToDo.Name;
          
        }
        
        private void btnPopupToDoEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (willBeUpdatedToDo != null)
                {
                    if (!string.IsNullOrEmpty(txtToDoEditName.Text))
                    {
                        willBeUpdatedToDo.Name = txtToDoEditName.Text;
                    }
                    else
                    {
                        popupToDoAdd.IsOpen = false;
                        MessageBox.Show("ToDo List information must be filled !");
                        popupToDoAdd.IsOpen = true;
                    }
                       
                    _toDoListService.Update(willBeUpdatedToDo);
                    txtToDoEditName.Text = "";
                    popupToDoEdit.IsOpen = false;
                    FillToDoListMenu(userId);
                    MessageBox.Show("ToDo List has been edited successfully.");
                }
                else
                {
                    MessageBox.Show("ToDo List has not been selected.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred : " + ex.Message);
            }
        }

        private void btnEditPopupClose_Click(object sender, RoutedEventArgs e)
        {
            popupToDoEdit.IsOpen = false;
            txtToDoEditName.Text = "";
        }
        #endregion Edit ToDoList

        #region Add ToDoList
        private void btnToDoAdd_Click(object sender, RoutedEventArgs e)
        {
            popupToDoAdd.IsOpen = true;
        }

        private void btnPopupToDoAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtToDoName.Text))
                {
                    ToDoList toDoList = new ToDoList()
                    {
                        Name = txtToDoName.Text,
                        UserId = userId
                    };
                    _toDoListService.Create(toDoList);
                    txtToDoName.Text = "";
                    popupToDoAdd.IsOpen = false;
                    FillToDoListMenu(userId);
                    MessageBox.Show("ToDo List has been added successfully.");

                }
                else
                {
                    popupToDoAdd.IsOpen = false;
                    MessageBox.Show("ToDo List information must be filled !");
                    popupToDoAdd.IsOpen = true;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred : " + ex.Message);
            }

        }

        private void btnPopupClose_Click(object sender, RoutedEventArgs e)
        {
            popupToDoAdd.IsOpen = false;
            txtToDoName.Text = "";
        }


        #endregion Add ToDoList

        #endregion Event Functions

       
    }
}
