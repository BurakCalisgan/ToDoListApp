using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApp.Entities;

namespace ToDoApp.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ToDoListContext();
            context.Database.Migrate();

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User() { FullName = "Burak Çalışgan", UserName = "burakcalisgan", Password = "123456" },
                    new User() { FullName = "user1", UserName = "user1", Password = "123456" }
                );
                context.SaveChanges();
            }

            if (!context.ToDoLists.Any())
            {
                var userIdList = context.Users.ToList();
                context.ToDoLists.AddRange(
                    new ToDoList() { Name = "Yapılacak 1", UserId = userIdList[0].Id },
                    new ToDoList() { Name = "Yapılacak 2", UserId = userIdList[1].Id },
                    new ToDoList() { Name = "Yapılacak 3", UserId = userIdList[0].Id },
                    new ToDoList() { Name = "Yapılacak 4", UserId = userIdList[1].Id }

                );
                context.SaveChanges();
            }
        }

    }
}
