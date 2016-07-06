namespace MyTodoApp.Core.Extensions.Navigation
{
    interface INavigationService
    {
        string CurrentPageKey { get; }

        void GoBack();

        void NavigateTo(string pageKey);

        void NavigateTo(string pageKey, object parameter);
    }
}