using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Entities;

namespace ToDoApp.Business.Abstract
{
    public interface IToDoListItemService
    {
        void Create(ToDoListItem entity);
        void Update(ToDoListItem entity);
        void Delete(ToDoListItem entity);

        List<ToDoListItem> GetToDoListItemsByToDoListId(int toDoListId);
    }
}
