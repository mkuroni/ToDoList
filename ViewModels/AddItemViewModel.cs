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
    /// <summary>
    /// ViewModel de la View pour ajouter des tâches à la liste.
    /// </summary>
    public class AddItemViewModel : ViewModelBase
    {
        private string _description;

        /// <summary>
        /// Constructeur du ViewModel qui initialise des commandes et actions à ses propriétés.
        /// </summary>
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

        /// <summary>
        /// Produit un TodoItem lorsqu'executé.
        /// </summary>
        public ReactiveCommand<Unit, TodoItem> Ok { get; }

        /// <summary>
        /// Produit un Unit lorsqu'executé (Équivalent de void).
        /// </summary>
        public ReactiveCommand<Unit, Unit> Cancel { get; }
    }
}
