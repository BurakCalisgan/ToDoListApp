using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.Entities;

namespace ToDoApp.DataAccess.Concrete.EfCore
{
    public class EfCoreUserDal : EfCoreGenericRepository<User, ToDoListContext>, IUserDal
    {
        public User GetByUserName(string userName)
        {
            using (var context = new ToDoListContext())
            {
                return context.Users.FirstOrDefault(x => x.UserName == userName);
            }
        }
    }
}
