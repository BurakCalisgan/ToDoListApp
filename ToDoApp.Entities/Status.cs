using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ToDoListItem> ToDoListItems { get; set; }
    }
}
