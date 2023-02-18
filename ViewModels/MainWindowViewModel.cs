using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Services;

namespace ToDoList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        public MainWindowViewModel(Database db)
        {
            //initialize Content avec ma liste. Va permettre d'intéragir avec Content.
            Content = List = new TodoListViewModel(db.GetItems());
        }

        public ViewModelBase Content
        {
            get => content;
            //Comme un onPropertyChanged pour rafraichir l'interface.
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public TodoListViewModel List { get; }

        public void AddItem()
        {
            Content = new AddItemViewModel();
        }
    }
}
