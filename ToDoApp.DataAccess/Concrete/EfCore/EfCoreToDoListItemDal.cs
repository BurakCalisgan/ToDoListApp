using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.Entities;

namespace ToDoApp.DataAccess.Concrete.EfCore
{
    public class EfCoreToDoListItemDal : EfCoreGenericRepository<ToDoListItem, ToDoListContext>, IToDoListItemDal
    {
        public List<ToDoListItem> GetToDoListItemsByToDoListId(int toDoListId)
        {
            using (var context = new ToDoListContext())
            {
                var toDoListItems = context.ToDoListItem
                                .Include(i => i.ToDoList)
                                .Where(i => i.ToDoList.Id== toDoListId)
                                .Include(i => i.Status)
                                .ToList();



                return toDoListItems;
            }
        }
    }
}
