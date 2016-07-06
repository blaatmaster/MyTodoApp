namespace MyTodoApp.ViewModels
{
    class TodoItemDetailsViewModel : ITodoItemDetailsViewModel
    {
        public string MainText { get; set; }

        public TodoItemDetailsViewModel()
        {
            MainText = "This is view 2.";
        }
    }
}