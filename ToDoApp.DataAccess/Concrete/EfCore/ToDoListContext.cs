using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Entities;

namespace ToDoApp.DataAccess.Concrete.EfCore
{
    public class ToDoListContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=ToDoListDb; integrated security=true");
        }
        //UserName unique olması için fonksiyonun içindeki satırlar yazıldı.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(b => b.UserName)
                .IsUnique();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoListItem> ToDoListItem { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
