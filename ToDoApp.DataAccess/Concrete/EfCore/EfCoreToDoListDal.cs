using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.Entities;

namespace ToDoApp.DataAccess.Concrete.EfCore
{
    public class EfCoreToDoListDal : EfCoreGenericRepository<ToDoList, ToDoListContext>, IToDoListDal
    {
        public List<ToDoList> GetToDoListByUserId(int userId)
        {
            using (var context = new ToDoListContext())
            {
                var toDoLists = context.ToDoLists
                                .Where(i => i.UserId == userId)
                                .ToList();



                return toDoLists;
            }
        }
    }
}
