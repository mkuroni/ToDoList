using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        private string _description;

        public AddItemViewModel()
        {
            //Pour la valeur initiale de Description et ses changements:
            //Assigne la valeur inverse de si Description est vide ou nulle à okEnabled.
            var okEnabled = this.WhenAnyValue(
                x => x.Description,
                x => !string.IsNullOrWhiteSpace(x));

            //Créer une commande qui est une lambda qui va créer un TodoItem avec la description entrée.
            Ok = ReactiveCommand.Create(
                () => new TodoItem { Description = Description },
                okEnabled);

            //Créer une commande qui ne fait rien. C'est un bouton qui va servir à quitter.
            Cancel = ReactiveCommand.Create(() => { });
        }

        /// <summary>
        /// Description observable
        /// </summary>
        public string Description
        {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }

        public ReactiveCommand<Unit, TodoItem> Ok { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }
    }
}
