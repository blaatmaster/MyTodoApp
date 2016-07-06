using System;

namespace MyTodoApp.ViewModels
{
    class TodoItemListViewModel : ITodoItemListViewModel
    {
        public String MainText { get; }

        public TodoItemListViewModel()
        {
            MainText = "Vlabrood";
        }
    }
}