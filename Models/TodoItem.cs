using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    /// <summary>
    /// Représente une tâche à faire.
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// Description textuelle de la tâche.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Si la tâche a été accomplie ou non.
        /// </summary>
        public bool IsChecked { get; set; }
    }
}
