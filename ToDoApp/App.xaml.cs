using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ToDoApp.Business.Abstract;
using ToDoApp.Business.Concrete;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.DataAccess.Concrete.EfCore;
using ToDoApp.View;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            ShutdownMode = ShutdownMode.OnExplicitShutdown;
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
        private void ConfigureServices(IServiceCollection services)
        {
            //DataAccess
            services.AddScoped<IUserDal, EfCoreUserDal>(); 
            services.AddScoped<IToDoListDal, EfCoreToDoListDal>();
            services.AddScoped<IToDoListItemDal, EfCoreToDoListItemDal>();
            services.AddScoped<IStatusDal, EfCoreStatusDal>();
            //Business
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IToDoListService, ToDoListManager>();
            services.AddScoped<IToDoListItemService, ToDoListItemManager>();
            services.AddScoped<IStatusService, StatusManager>();

            services.AddScoped<LoginPage>();
            services.AddScoped<RegisterPage>();
            services.AddScoped<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            SeedDatabase.Seed();
            //İlk açıldığı anda kuruculardaki interfaceleri initial etmek için kullanıyoruz.
            _serviceProvider.GetService<RegisterPage>();
            _serviceProvider.GetService<MainWindow>();
            var loginWindow = _serviceProvider.GetService<LoginPage>();
            
            loginWindow.Show();
        }
        
    }
}
