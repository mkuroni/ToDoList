using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    /// <summary>
    /// ViewModel de la liste de tâche
    /// </summary>
    public class TodoListViewModel : ViewModelBase
    {
        /// <summary>
        /// Assigne sa liste de tâches par défaut.
        /// </summary>
        /// <param name="items">La liste de tâches initiales</param>
        public TodoListViewModel(IEnumerable<TodoItem> items) 
        {
            Items = new ObservableCollection<TodoItem>(items);
        }

        /// <summary>
        /// La liste de tâche sur laquelle Bind dans la View.
        /// </summary>
        public ObservableCollection<TodoItem> Items { get; }
    }
}
