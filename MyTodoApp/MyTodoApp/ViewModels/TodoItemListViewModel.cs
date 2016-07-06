using MyTodoApp.Core.Extensions.Dialogs;
using MyTodoApp.Core.Extensions.Navigation;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyTodoApp.ViewModels
{
    class TodoItemListViewModel : ITodoItemListViewModel
    {
        public String MainText { get; }

        public ICommand NextPageCommand { get; private set; }

        private INavigationService _navigationService;
        private IDialogService _dialogService;

        public TodoItemListViewModel(
            INavigationService navigationService,
            IDialogService dialogService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            if (dialogService == null) throw new ArgumentNullException("dialogService");

            MainText = "Vlabrood";

            NextPageCommand = new Command(NextPage);

            _navigationService = navigationService;
            _dialogService = dialogService;
        }

        private void NextPage()
        {
            //_dialogService.ShowMessage("This is a message","My Title");
            _navigationService.NavigateTo(App.PageTodoItemDetails);
        }
    }
}