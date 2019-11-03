using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Business.Abstract;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.Entities;

namespace ToDoApp.Business.Concrete
{
    public class ToDoListItemManager : IToDoListItemService
    {
        private IToDoListItemDal _toDoListItemDal;
        public ToDoListItemManager(IToDoListItemDal toDoListItemDal)
        {
            _toDoListItemDal = toDoListItemDal;
        }
        public void Create(ToDoListItem entity)
        {
            _toDoListItemDal.Create(entity);
        }

        public void Delete(ToDoListItem entity)
        {
            _toDoListItemDal.Delete(entity);
        }

        public ToDoListItem GetById(int id)
        {
            return _toDoListItemDal.GetById(id);
        }

        public List<ToDoListItem> GetToDoListItemsByToDoListId(int toDoListId)
        {
            return _toDoListItemDal.GetToDoListItemsByToDoListId(toDoListId);
        }

        public void Update(ToDoListItem entity)
        {
            _toDoListItemDal.Update(entity);
        }
    }
}
