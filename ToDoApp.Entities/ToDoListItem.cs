using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Entities
{
    public class ToDoListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public int StatuId { get; set; }
        public Status Status { get; set; }
        public int ToDoListId { get; set; }
        public ToDoList ToDoList { get; set; }
    }
}
