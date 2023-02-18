using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services
{
    /// <summary>
    /// Base de données fictive de l'application
    /// </summary>
    public class Database
    {
        /// <summary>
        /// Un accesseur à nos données
        /// </summary>
        /// <returns>Un tableau de "TodoItem"</returns>
        public IEnumerable<TodoItem> GetItems() => new[]
        {
            new TodoItem { Description = "Promener le chien"},
            new TodoItem { Description = "Acheter du lait"},
            new TodoItem { Description = "Apprendre Avalonia"},
        };
    }
}
