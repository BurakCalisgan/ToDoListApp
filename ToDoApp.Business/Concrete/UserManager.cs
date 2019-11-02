using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Business.Abstract;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.Entities;

namespace ToDoApp.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Create(User entity)
        {
            _userDal.Create(entity);
        }

        public User GetById(int id)
        {
            return _userDal.GetById(id);
        }

        public User GetByUserName(string userName)
        {
            return _userDal.GetByUserName(userName);
        }
    }
}
