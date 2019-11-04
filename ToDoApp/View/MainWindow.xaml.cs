using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToDoApp.Business.Abstract;
using ToDoApp.Entities;
using ToDoApp.Model;

namespace ToDoApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static IUserService _userService;
        private static IToDoListService _toDoListService;
        private static IToDoListItemService _toDoListItemService;
        private static IStatusService _statusService;
        public int userId;
        public int selectedToDoListId;

        public MainWindow()
        {
            InitializeComponent();

            userId = Convert.ToInt32(Application.Current.Properties["UserId"]);

            if (userId != 0)
            {
                FillToDoListMenu(userId);
                FillUserInfo();
                FillCmnbFilter();
            }

        }
        public MainWindow(IUserService userService, IToDoListService toDoListService, IToDoListItemService toDoListItemService, IStatusService statusService)
        {
            _userService = userService;
            _toDoListService = toDoListService;
            _toDoListItemService = toDoListItemService;
            _statusService = statusService;
        }

        #region Fiil Functions
        public void FillToDoListMenu(int userId)
        {
            ToDoListMenu.ItemsSource = _toDoListService.GetToDoListByUserId(userId);
        }

        public void FillToDoListItemGrid(int ToDoListId)
        {
            var toDoListItems = _toDoListItemService.GetToDoListItemsByToDoListId(ToDoListId);
            List<ToDoListItemModel> list = new List<ToDoListItemModel>();
            list = toDoListItems.Select(i => new ToDoListItemModel()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                StartDate = i.StartDate,
                DeadLine = i.DeadLine,
                Status = DateTime.Now > i.DeadLine ? "Expired" : i.Status.Name,
                IsCompleted = i.Status.Id != 2 ? false : true
            }).ToList();
            lvToDoListItem.ItemsSource = list;
        }

        public void FillToDoListItemGridByOrderCase(int index)
        {
            //0 default
            //1 start date
            //2 deadline
            //3 name
            if (selectedToDoListId == 0)
            {
                return;
            }
            if (index == 0)
            {
                var toDoListItems = _toDoListItemService.GetToDoListItemsByToDoListId(selectedToDoListId);
                List<ToDoListItemModel> list = new List<ToDoListItemModel>();
                list = toDoListItems.Select(i => new ToDoListItemModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    StartDate = i.StartDate,
                    DeadLine = i.DeadLine,
                    Status = DateTime.Now > i.DeadLine ? "Expired" : i.Status.Name,
                    IsCompleted = i.Status.Id != 2 ? false : true
                }).ToList();
                lvToDoListItem.ItemsSource = list;
            }
            else if (index == 1)
            {
                var toDoListItems = _toDoListItemService.GetToDoListItemsByToDoListId(selectedToDoListId);
                List<ToDoListItemModel> list = new List<ToDoListItemModel>();
                list = toDoListItems.Select(i => new ToDoListItemModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    StartDate = i.StartDate,
                    DeadLine = i.DeadLine,
                    Status = DateTime.Now > i.DeadLine ? "Expired" : i.Status.Name,
                    IsCompleted = i.Status.Id != 2 ? false : true
                }).OrderBy(i => i.StartDate)
                .ToList();
                lvToDoListItem.ItemsSource = list;
            }
            else if (index == 2)
            {
                var toDoListItems = _toDoListItemService.GetToDoListItemsByToDoListId(selectedToDoListId);
                List<ToDoListItemModel> list = new List<ToDoListItemModel>();
                list = toDoListItems.Select(i => new ToDoListItemModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    StartDate = i.StartDate,
                    DeadLine = i.DeadLine,
                    Status = DateTime.Now > i.DeadLine ? "Expired" : i.Status.Name,
                    IsCompleted = i.Status.Id != 2 ? false : true
                }).OrderBy(i => i.DeadLine)
                .ToList();
                lvToDoListItem.ItemsSource = list;
            }
            else if (index == 3)
            {
                var toDoListItems = _toDoListItemService.GetToDoListItemsByToDoListId(selectedToDoListId);
                List<ToDoListItemModel> list = new List<ToDoListItemModel>();
                list = toDoListItems.Select(i => new ToDoListItemModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    StartDate = i.StartDate,
                    DeadLine = i.DeadLine,
                    Status = DateTime.Now > i.DeadLine ? "Expired" : i.Status.Name,
                    IsCompleted = i.Status.Id != 2 ? false : true
                }).OrderBy(i => i.Name)
                .ToList();
                lvToDoListItem.ItemsSource = list;
            }
        }

        public void FillUserInfo()
        {
            User userInfo = _userService.GetById(userId);
            txtUserFullName.Text = userInfo.FullName;
        }

        public void FillCmnbFilter()
        {
            var list = _statusService.GetAll();
            list.Add(new Status()
            {
                Id = 0,
                Name = "Chose for Filter"
            });
            list.Add(new Status()
            {
                Id = -1,
                Name = "Expired"
            });

            cmbFilter.ItemsSource = list;
        }

        public void FillToDoListItemGridByFilterCase(int id)
        {
            //-1 Expired
            //0 Default
            //1 Not Completed
            //2 Completed
            if (selectedToDoListId == 0)
            {
                return;
            }
            if (id == -1)
            {
                var toDoListItems = _toDoListItemService.GetToDoListItemsByToDoListId(selectedToDoListId);
                List<ToDoListItemModel> list = new List<ToDoListItemModel>();
                list = toDoListItems.Select(i => new ToDoListItemModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    StartDate = i.StartDate,
                    DeadLine = i.DeadLine,
                    Status = DateTime.Now > i.DeadLine ? "Expired" : i.Status.Name,
                    IsCompleted = i.Status.Id != 2 ? false : true
                })
                .Where(i => i.Status == "Expired")
                .ToList();
                lvToDoListItem.ItemsSource = list;
            }
            else if (id == 0)
            {
                var toDoListItems = _toDoListItemService.GetToDoListItemsByToDoListId(selectedToDoListId);
                List<ToDoListItemModel> list = new List<ToDoListItemModel>();
                list = toDoListItems.Select(i => new ToDoListItemModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    StartDate = i.StartDate,
                    DeadLine = i.DeadLine,
                    Status = DateTime.Now > i.DeadLine ? "Expired" : i.Status.Name,
                    IsCompleted = i.Status.Id != 2 ? false : true
                })
                .ToList();
                lvToDoListItem.ItemsSource = list;
            }
            else if (id == 1)
            {
                var toDoListItems = _toDoListItemService.GetToDoListItemsByToDoListId(selectedToDoListId);
                List<ToDoListItemModel> list = new List<ToDoListItemModel>();
                toDoListItems = toDoListItems.Where(i => i.StatusId == id).ToList();
                list = toDoListItems.Select(i => new ToDoListItemModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    StartDate = i.StartDate,
                    DeadLine = i.DeadLine,
                    Status = DateTime.Now > i.DeadLine ? "Expired" : i.Status.Name,
                    IsCompleted = i.Status.Id != 2 ? false : true
                })
                .Where(i => i.Status != "Expired")
                .ToList();
                lvToDoListItem.ItemsSource = list;
            }
            else if (id == 2)
            {
                var toDoListItems = _toDoListItemService.GetToDoListItemsByToDoListId(selectedToDoListId);
                List<ToDoListItemModel> list = new List<ToDoListItemModel>();
                toDoListItems = toDoListItems.Where(i => i.StatusId == id).ToList();
                list = toDoListItems.Select(i => new ToDoListItemModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    StartDate = i.StartDate,
                    DeadLine = i.DeadLine,
                    Status = i.Status.Name,
                    IsCompleted = i.Status.Id != 2 ? false : true
                })
                .ToList();
                lvToDoListItem.ItemsSource = list;
            }
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
            var toDoList = (ToDoList)ToDoListMenu.SelectedItem;
            if (toDoList !=null)
            {
                selectedToDoListId = toDoList.Id;
                FillToDoListItemGrid(selectedToDoListId);
            }
           
            if (index != -1)
            {
                MoveCursorMenu(index);
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


        #region Add ToDo List Item
        private void btnToDoListItemAdd_Click(object sender, RoutedEventArgs e)
        {
            popupToDoListItemAdd.IsOpen = true;
        }

        private void btnPopupToDoItemAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtToDoItemName.Text) || !string.IsNullOrEmpty(txtToDoItemName.Text) || txtToDoItemStartDate.SelectedDate.Value != null || txtToDoItemDeadLine.SelectedDate.Value != null)
                {
                    ToDoListItem toDoListItem = new ToDoListItem()
                    {
                        Name = txtToDoItemName.Text,
                        Description = txtToDoItemDescription.Text,
                        StartDate = txtToDoItemStartDate.SelectedDate.Value,
                        DeadLine = txtToDoItemDeadLine.SelectedDate.Value,
                        StatusId = 1,
                        ToDoListId = selectedToDoListId
                    };

                    _toDoListItemService.Create(toDoListItem);
                    txtToDoItemDescription.Text = "";
                    txtToDoItemName.Text = "";
                    txtToDoItemStartDate.Text = null;
                    txtToDoItemDeadLine.Text = null;
                    popupToDoListItemAdd.IsOpen = false;
                    FillToDoListItemGrid(selectedToDoListId);
                    MessageBox.Show("ToDo List Item has been added successfully.");

                }
                else
                {
                    popupToDoListItemAdd.IsOpen = false;
                    MessageBox.Show("ToDo List Item information must be filled !");
                    popupToDoListItemAdd.IsOpen = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred : " + ex.Message);
            }
        }

        private void btnToDoItemPopupClose_Click(object sender, RoutedEventArgs e)
        {
            popupToDoListItemAdd.IsOpen = false;
            txtToDoItemName.Text = "";
            txtToDoItemDescription.Text = "";
            txtToDoItemStartDate.Text = null;
            txtToDoItemDeadLine.Text = null;
        }
        #endregion Add ToDo List Item

        #region Delete ToDo List Item
        private void ToDoListItem_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = sender as Button;
                ToDoListItemModel deleteItem = button.DataContext as ToDoListItemModel;
                var toDoListItem = _toDoListItemService.GetById(deleteItem.Id);

                if (toDoListItem != null)
                {
                    _toDoListItemService.Delete(toDoListItem);
                    FillToDoListItemGrid(selectedToDoListId);
                    MessageBox.Show("ToDo List Item has been deleted successfully.");
                }
                else
                {
                    MessageBox.Show("ToDo List Item has not been selected.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred : " + ex.Message);
            }
        }

        #endregion Delete ToDo List Item

        #region Update  ToDo List Item
        ToDoListItemModel willbeUpdateItemModel;
        private void ToDoListItem_Edit_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            popupToDoListItemEdit.IsOpen = true;
            willbeUpdateItemModel = button.DataContext as ToDoListItemModel;
            txtToDoItemEditName.Text = willbeUpdateItemModel.Name;
            txtToDoItemEditDescription.Text = willbeUpdateItemModel.Description;
            txtToDoItemEditStartDate.Text = willbeUpdateItemModel.StartDate.ToString();
            txtToDoItemEditDeadLine.Text = willbeUpdateItemModel.DeadLine.ToString();
        }

        private void btnPopupToDoItemEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (willbeUpdateItemModel != null)
                {
                    var toDoListItem = _toDoListItemService.GetById(willbeUpdateItemModel.Id);
                    if (!string.IsNullOrEmpty(txtToDoItemEditName.Text) || !string.IsNullOrEmpty(txtToDoItemEditDescription.Text) || !string.IsNullOrEmpty(txtToDoItemEditStartDate.Text) || !string.IsNullOrEmpty(txtToDoItemEditDeadLine.Text))
                    {
                        toDoListItem.Name = txtToDoItemEditName.Text;
                        toDoListItem.Description = txtToDoItemEditDescription.Text;
                        toDoListItem.StartDate = Convert.ToDateTime(txtToDoItemEditStartDate.Text);
                        toDoListItem.DeadLine = Convert.ToDateTime(txtToDoItemEditDeadLine.Text);

                    }
                    else
                    {
                        popupToDoAdd.IsOpen = false;
                        MessageBox.Show("ToDo List information must be filled !");
                        popupToDoAdd.IsOpen = true;
                    }

                    _toDoListItemService.Update(toDoListItem);
                    txtToDoItemEditName.Text = "";
                    txtToDoItemEditDescription.Text = "";
                    txtToDoItemEditStartDate.Text = null;
                    txtToDoItemEditDeadLine.Text = null;
                    popupToDoListItemEdit.IsOpen = false;
                    FillToDoListItemGrid(selectedToDoListId);
                    MessageBox.Show("ToDo List Item has been edited successfully.");
                }
                else
                {
                    MessageBox.Show("ToDo List Item has not been selected.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred : " + ex.Message);
            }
        }

        private void btnToDoItemEditPopupClose_Click(object sender, RoutedEventArgs e)
        {
            popupToDoListItemEdit.IsOpen = false;
            txtToDoItemEditName.Text = "";
            txtToDoItemEditDescription.Text = "";
            txtToDoItemEditStartDate.Text = null;
            txtToDoItemEditDeadLine.Text = null;
        }

        private void chkToDoListItem_Completed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckBox checkBox = sender as CheckBox;
                ToDoListItemModel updateItem = checkBox.DataContext as ToDoListItemModel;
                var toDoListItem = _toDoListItemService.GetById(updateItem.Id);

                if (toDoListItem != null)
                {
                    if (checkBox.IsChecked == true)
                    {
                        toDoListItem.StatusId = 2;
                    }
                    else
                    {
                        toDoListItem.StatusId = 1;
                    }
                    _toDoListItemService.Update(toDoListItem);
                    FillToDoListItemGrid(selectedToDoListId);
                    MessageBox.Show("ToDo List Item has been updated for complete successfully.");
                }
                else
                {
                    MessageBox.Show("ToDo List Item has not been selected.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred : " + ex.Message);
            }

        }









        #endregion Update  ToDo List Item

        #region Order
        private void cmbOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = cmbOrder.SelectedIndex;
            FillToDoListItemGridByOrderCase(index);

        }


        #endregion Order

        #region Filter

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Status status = cmbFilter.SelectedItem as Status;
            FillToDoListItemGridByFilterCase(status.Id);
        }

        #endregion Filter

        #endregion Event Functions


       
    }
}
