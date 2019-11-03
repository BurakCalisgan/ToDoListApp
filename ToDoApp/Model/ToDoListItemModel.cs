using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Model
{
    public class ToDoListItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public string Status { get; set; }
        public bool IsCompleted { get; set; }
       
    }
}
