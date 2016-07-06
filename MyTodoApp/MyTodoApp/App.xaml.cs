using Autofac;
using MyTodoApp.Core.Extensions.Dialogs;
using MyTodoApp.Core.Extensions.Navigation;
using MyTodoApp.Core.Factories;
using MyTodoApp.Repositories;
using MyTodoApp.Services;
using MyTodoApp.ViewModels;
using MyTodoApp.Views;
using Xamarin.Forms;

namespace MyTodoApp
{
    public partial class App : Application
    {
        public const string PageTodoItemList = "TodoItemList";
        public const string PageTodoItemDetails = "TodoItemDetails";

        private IContainer _container;

        /// <summary>
        ///
        /// </summary>
        public App()
        {
            InitializeComponent();

            //MainPage = new MyTodoApp.MainPage();
            Configure();
        }

        /// <summary>
        ///
        /// </summary>
        protected void Configure()
        {
            ContainerBuilder cb = new ContainerBuilder();

            /// INFRASTRUCTURE
            ///

            // ViewFactory
            cb.RegisterType<ViewFactory>()
                .As<IViewFactory>()
                .SingleInstance();

            // NavigationService ==> TODO: Instance, because it should initialized further on. Navigation page is set. Possible other way?
            NavigationService navigationService = new NavigationService();
            cb.RegisterInstance(navigationService)
                .As<INavigationService>()
                .SingleInstance();

            // DialogService ==> TODO: Instance, because it should initialized further on. Navigation page is set. Possible other way?
            DialogService dialogService = new DialogService();
            cb.RegisterInstance(dialogService)
                .As<IDialogService>()
                .SingleInstance();

            /// APPLICATION SPECIFIC
            ///

            // Repositories
            cb.RegisterType<TodoItemRepository>().As<ITodoItemRepository>().SingleInstance();

            // Services
            cb.RegisterType<TodoItemService>().As<ITodoItemService>().SingleInstance();

            // ViewModels
            cb.RegisterType<TodoItemListViewModel>().As<TodoItemListViewModel>().SingleInstance();
            cb.RegisterType<TodoItemDetailsViewModel>().As<TodoItemDetailsViewModel>().SingleInstance();

            // Views
            cb.RegisterType<TodoItemListView>().SingleInstance();
            cb.RegisterType<TodoItemDetailsView>().SingleInstance();

            // Build Container
            _container = cb.Build();

            // Map ViewModels => Views
            var viewFactory = _container.Resolve<IViewFactory>();

            viewFactory.Register<TodoItemListViewModel, TodoItemListView>();
            viewFactory.Register<TodoItemDetailsViewModel, TodoItemDetailsView>();

            navigationService.Configure(App.PageTodoItemList, );

            // Set the main page...
            var mainPage = viewFactory.Resolve<TodoItemListViewModel>();
            var navigationPage = new NavigationPage(mainPage);

            navigationService.Initialize(navigationPage);
            dialogService.Initialize(navigationPage);

            MainPage = navigationPage;
        }

        /// <summary>
        ///
        /// </summary>
        protected void Execute()
        {
        }

        /////////////

        /// <summary>
        ///
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}