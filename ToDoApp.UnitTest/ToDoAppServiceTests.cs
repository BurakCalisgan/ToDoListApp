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
            Random rastgele = new Random();
            int sayi = rastgele.Next();
            User user = new User()
            {
                FullName = "testuser" + sayi,
                UserName = "testuser" + sayi,
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
            Random rastgele = new Random();
            int sayi = rastgele.Next();
            User createdUser = new User()
            {
                FullName = "testuser" + sayi,
                UserName = "testuser" + sayi,
                Password = "testuser"
            };
            repo.Create(createdUser);

            User user = repo.GetById(createdUser.Id);
            user.Password = "unittest";
            int expeted = 1;
            var actual = repo.Update(user);
            Assert.Equal(expeted, actual);

        }

        [Fact]
        public void UserManagerDeleteReturnControl()
        {
            EfCoreGenericRepository<User, ToDoListContext> repo = new EfCoreGenericRepository<User, ToDoListContext>();
            Random rastgele = new Random();
            int sayi = rastgele.Next();
            User createdUser = new User()
            {
                FullName = "testuser" + sayi,
                UserName = "testuser" + sayi,
                Password = "testuser"
            };
            repo.Create(createdUser);
            var user = repo.GetById(createdUser.Id);

            int expeted = 1;
            var actual = repo.Delete(user);
            Assert.Equal(expeted, actual);

        }
    }
}
