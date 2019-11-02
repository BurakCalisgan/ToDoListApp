using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Entities;

namespace ToDoApp.Business.Abstract
{
    public interface IUserService
    {
        void Create(User entity);
        User GetById(int id);
        User GetByUserName(string userName);
    }
}
