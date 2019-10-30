using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Entities;

namespace ToDoApp.DataAccess.Abstract
{
    public interface IUserDal : IRepository<User>
    {
    }
}
