using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
