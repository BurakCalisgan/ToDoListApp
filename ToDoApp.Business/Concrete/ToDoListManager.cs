using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Business.Abstract;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.Entities;

namespace ToDoApp.Business.Concrete
{
    public class ToDoListManager : IToDoListService
    {
        private IToDoListDal _toDoListDal;
        public ToDoListManager(IToDoListDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }

        public void Create(ToDoList entity)
        {
            _toDoListDal.Create(entity);
        }

        public void Delete(ToDoList entity)
        {
            _toDoListDal.Delete(entity);
        }

        public List<ToDoList> GetToDoListByUserId(int userId)
        {
            return _toDoListDal.GetToDoListByUserId(userId);
        }

        public void Update(ToDoList entity)
        {
            _toDoListDal.Update(entity);

        }
    }
}
