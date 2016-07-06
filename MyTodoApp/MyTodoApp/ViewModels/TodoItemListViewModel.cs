using MyTodoApp.Core.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
