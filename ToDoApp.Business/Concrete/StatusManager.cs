using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Business.Abstract;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.Entities;

namespace ToDoApp.Business.Concrete
{
    public class StatusManager : IStatusService
    {
        private IStatusDal _statusDal;
        public StatusManager(IStatusDal statusDal)
        {
            _statusDal = statusDal;
        }
        public List<Status> GetAll()
        {
            return _statusDal.GetAll();
        }
    }
}
