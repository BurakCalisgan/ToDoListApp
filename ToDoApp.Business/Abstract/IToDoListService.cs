using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Entities;

namespace ToDoApp.Business.Abstract
{
    public interface IToDoListService
    {
        void Create(ToDoList entity);
        void Update(ToDoList entity);
        void Delete(ToDoList entity);
        List<ToDoList> GetToDoListByUserId(int userId);
    }
}
