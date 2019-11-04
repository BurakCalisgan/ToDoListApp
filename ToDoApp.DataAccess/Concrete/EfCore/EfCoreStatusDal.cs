using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.Entities;

namespace ToDoApp.DataAccess.Concrete.EfCore
{
    public class EfCoreStatusDal : EfCoreGenericRepository<Status, ToDoListContext>, IStatusDal
    {
    }
}
