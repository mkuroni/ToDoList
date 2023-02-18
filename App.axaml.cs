using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ToDoList.Services;
using ToDoList.ViewModels;
using ToDoList.Views;

namespace ToDoList
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                //Cr�er une fausse base de donn�e. En application, un EntityFramework serait tr�s int�ressant.
                var db = new Database();

                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(db), //On donne la bd au constructeur du viewmodel principal
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
