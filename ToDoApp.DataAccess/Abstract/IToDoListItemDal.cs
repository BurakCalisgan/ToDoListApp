using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Entities;

namespace ToDoApp.DataAccess.Abstract
{
    public interface IToDoListItemDal : IRepository<ToDoListItem>
    {
        List<ToDoListItem> GetToDoListItemsByToDoListId(int toDoListId);
    }
}
