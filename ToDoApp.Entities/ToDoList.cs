using System;
using System.Collections.Generic;

namespace ToDoApp.Entities
{
    public class ToDoList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public List<ToDoListItem> ToDoListItems { get; set; }
    }
}
