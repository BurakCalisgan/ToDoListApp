using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Entities;

namespace ToDoApp.Business.Abstract
{
    public interface IStatusService
    {
        List<Status> GetAll();
    }
}
