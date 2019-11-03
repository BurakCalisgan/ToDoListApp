using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ToDoApp.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        T GetById(int id);
        T GetOne(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        int Create(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
