using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewModels
{
    /// <summary>
    /// ViewModel de la fenêtre principale (Le conteneur)
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;

        /// <summary>
        /// Le constructeur par défaut initialise son contenu avec la vue sur la liste de tâches.
        /// </summary>
        /// <param name="db">La Base de donnée</param>
        public MainWindowViewModel(Database db)
        {
            //initialize Content avec un ViewModel pour le User Control qui affiche la liste des tâches.
            Content = List = new TodoListViewModel(db.GetItems());//Il prends la base de données pour afficher les tâches.
        }

        /// <summary>
        /// Accesseur Bind sur "Content" de la View. Permet d'accéder plus facilement et de changer son état lorsque sur d'autres vues.
        /// </summary>
        public ViewModelBase Content
        {
            get => content;
            //Comme un onPropertyChanged pour rafraichir l'interface.
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }
        /// <summary>
        /// Le ViewModel de la liste de tâches.
        /// </summary>
        public TodoListViewModel List { get; }

        /// <summary>
        /// Créer le viewModel et les fonctions nécessaires aux différents boutons de la vue d'ajout de tâche.
        /// </summary>
        public void AddItem()
        {
            var vm = new AddItemViewModel();

            //Combine la sortie d'un nombre infini d'observables et les "merges" dans un seul canal observable. (Un genre de 'payload')
            Observable.Merge(
                vm.Ok,
                vm.Cancel.Select(_ => (TodoItem)null)) //Chaque fois que Cancel est appelé, on produit un TodoItem null.
                .Take(1) //On s'intéresse seulement au premier click produit sur un bouton. (Il prend donc seulement la première valeur)
                .Subscribe(model => //On subscribe au résultat.
                {
                    if (model != null) //Lorsque le résultat n'est pas null (donc bouton Ok), on ajoute le todoitem à la liste. 
                    {
                        List.Items.Add(model);
                    }
                    Content = List; //On remet List comme contenu visuel
                });
            Content = vm;
        }
    }
}
