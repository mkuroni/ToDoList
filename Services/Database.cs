using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class Database
    {
        public IEnumerable<TodoItem> GetItems() => new[]
        {
            new TodoItem { Description = "Promener le chien"},
            new TodoItem { Description = "Acheter du lait"},
            new TodoItem { Description = "Apprendre Avalonia"},
        };
    }
}
