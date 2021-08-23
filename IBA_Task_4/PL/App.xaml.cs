using BLL.Contracts;
using BLL.HostBuilders;
using BLL.Services;
using BLL.Stores;
using BLL.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PL.Views;
using System;
using System.Windows;

namespace PL
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();

            IServiceCollection services = new ServiceCollection();
            
            services.AddSingleton<AccountStore>();
            services.AddSingleton<ModalNavigationStore>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ProjectsStore>();
            services.AddSingleton<UsersStore>();
            services.AddSingleton<TasksStore>();
            services.AddSingleton<ChatRoomsStore>();
            services.AddSingleton<UserService>();
            //services.AddDbContext<DAL.Context.AppDbContext>();

            services.AddSingleton<INavigationService>(s => CreateHomeNavigationService(s));
            services.AddSingleton<CloseModalNavigationService>();

            services.AddTransient<HomeViewModel>(s => new HomeViewModel(CreateLoginNavigationService(s),
                CreateRegistrationNavigationService(s)));
            services.AddTransient<AccountViewModel>(s => new AccountViewModel(
                s.GetRequiredService<AccountStore>(),
                CreateHomeNavigationService(s)));
            services.AddTransient<LoginViewModel>(s => new LoginViewModel(
                s.GetRequiredService<AccountStore>(),
                CreateHomeNavigationService(s),
                _host.Services.GetRequiredService<IUserService>()));
            services.AddTransient<RegistrationViewModel>(s => new RegistrationViewModel(
                s.GetRequiredService<AccountStore>(),
                CreateHomeNavigationService(s),
               _host.Services.GetRequiredService<IUserService>()));


            services.AddTransient<ProjectsListingViewModel>(s => new ProjectsListingViewModel(
                s.GetRequiredService<ProjectsStore>(),
                CreateAddProjectNavigationService(s)));
            services.AddTransient<AddProjectViewModel>(s => new AddProjectViewModel(
                s.GetRequiredService<ProjectsStore>(),
                s.GetRequiredService<CloseModalNavigationService>()
                ));

            services.AddTransient<UsersListingViewModel>(s => new UsersListingViewModel(
                s.GetRequiredService<UsersStore>(),
                CreateAddUserNavigationService(s)));
            services.AddTransient<AddUserViewModel>(s => new AddUserViewModel(
                s.GetRequiredService<UsersStore>(),
                s.GetRequiredService<CloseModalNavigationService>()
                ));

            services.AddTransient<TasksListingViewModel>(s => new TasksListingViewModel(
                s.GetRequiredService<TasksStore>(),
                CreateHomeNavigationService(s),
               s.GetRequiredService<UserService>()));
            services.AddTransient<AddTaskViewModel>(s => new AddTaskViewModel(
                s.GetRequiredService<TasksStore>(),
                s.GetRequiredService<CloseModalNavigationService>()
                ));

            services.AddTransient<ChatRoomsListingViewModel>(s => new ChatRoomsListingViewModel(
                s.GetRequiredService<ChatRoomsStore>(),
                CreateAddTaskNavigationService(s)));
            services.AddTransient<AddChatRoomViewModel>(s => new AddChatRoomViewModel(
                s.GetRequiredService<ChatRoomsStore>(),
                s.GetRequiredService<CloseModalNavigationService>()
                ));

            services.AddTransient<NavigationBarViewModel>(CreateNavigationBarViewModel);
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }
        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .AddViews()
                .AddDbContext()
                .AddServices();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }

            base.OnExit(e);
        }

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<LoginViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<LoginViewModel>());
        }

        private INavigationService CreateRegistrationNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<RegistrationViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<RegistrationViewModel>());
        }

        private INavigationService CreateAddProjectNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<ProjectViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<ProjectViewModel>());
        }

        private INavigationService CreateAddUserNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddUserViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddUserViewModel>());
        }

        private INavigationService CreateAddTaskNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<TaskViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<TaskViewModel>());
        }

        private INavigationService CreateAccountNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<AccountViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<AccountViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateProjectsListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<ProjectsListingViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ProjectsListingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateUsersListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<UsersListingViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<UsersListingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateTasksListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<TasksListingViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<TasksListingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateChatRoomsListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<ChatRoomsListingViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ChatRoomsListingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(serviceProvider.GetRequiredService<AccountStore>(),
                CreateHomeNavigationService(serviceProvider),
                CreateAccountNavigationService(serviceProvider),
                CreateLoginNavigationService(serviceProvider),
                CreateRegistrationNavigationService(serviceProvider),
                CreateProjectsListingNavigationService(serviceProvider),
                CreateTasksListingNavigationService(serviceProvider),
                CreateUsersListingNavigationService(serviceProvider),
                CreateChatRoomsListingNavigationService(serviceProvider));
        }
    }
}
