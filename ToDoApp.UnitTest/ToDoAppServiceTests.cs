using System;
using ToDoApp.DataAccess.Concrete.EfCore;
using ToDoApp.Entities;
using Xunit;

namespace ToDoApp.UnitTest
{
    public class ToDoAppDataAccessTests
    {
        [Fact]
        public void UserManagerCreateReturnControl()
        {
            EfCoreGenericRepository<User, ToDoListContext> repo = new EfCoreGenericRepository<User, ToDoListContext>();
            User user = new User()
            {
                FullName = "testuser",
                UserName = "testuser",
                Password = "testuser"
            };
            int expeted = 1;
            var actual = repo.Create(user);
            Assert.Equal(expeted, actual);
        
        }

        [Fact]
        public void UserManagerUpdateReturnControl()
        {
            EfCoreGenericRepository<User, ToDoListContext> repo = new EfCoreGenericRepository<User, ToDoListContext>();

            User user = new User()
            {
                Id = 1007,
                FullName = "Test2",
                UserName = "test2",
                Password = "test2"
            };
            int expeted = 1;
            var actual = repo.Update(user);
            Assert.Equal(expeted, actual);

        }

        [Fact]
        public void UserManagerDeleteReturnControl()
        {
            EfCoreGenericRepository<User, ToDoListContext> repo = new EfCoreGenericRepository<User, ToDoListContext>();
            var user = repo.GetById(1009);
            int expeted = 1;
            var actual = repo.Delete(user);
            Assert.Equal(expeted, actual);

        }
    }
}
