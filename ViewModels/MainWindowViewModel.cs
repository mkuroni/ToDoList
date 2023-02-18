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
    /// ViewModel de la fen�tre principale (Le conteneur)
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;

        /// <summary>
        /// Le constructeur par d�faut initialise son contenu avec la vue sur la liste de t�ches.
        /// </summary>
        /// <param name="db">La Base de donn�e</param>
        public MainWindowViewModel(Database db)
        {
            //initialize Content avec un ViewModel pour le User Control qui affiche la liste des t�ches.
            Content = List = new TodoListViewModel(db.GetItems());//Il prends la base de donn�es pour afficher les t�ches.
        }

        /// <summary>
        /// Accesseur Bind sur "Content" de la View. Permet d'acc�der plus facilement et de changer son �tat lorsque sur d'autres vues.
        /// </summary>
        public ViewModelBase Content
        {
            get => content;
            //Comme un onPropertyChanged pour rafraichir l'interface.
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }
        /// <summary>
        /// Le ViewModel de la liste de t�ches.
        /// </summary>
        public TodoListViewModel List { get; }

        /// <summary>
        /// Cr�er le viewModel et les fonctions n�cessaires aux diff�rents boutons de la vue d'ajout de t�che.
        /// </summary>
        public void AddItem()
        {
            var vm = new AddItemViewModel();

            //Combine la sortie d'un nombre infini d'observables et les "merges" dans un seul canal observable. (Un genre de 'payload')
            Observable.Merge(
                vm.Ok,
                vm.Cancel.Select(_ => (TodoItem)null)) //Chaque fois que Cancel est appel�, on produit un TodoItem null.
                .Take(1) //On s'int�resse seulement au premier click produit sur un bouton. (Il prend donc seulement la premi�re valeur)
                .Subscribe(model => //On subscribe au r�sultat.
                {
                    if (model != null) //Lorsque le r�sultat n'est pas null (donc bouton Ok), on ajoute le todoitem � la liste. 
                    {
                        List.Items.Add(model);
                    }
                    Content = List; //On remet List comme contenu visuel
                });
            Content = vm;
        }
    }
}
