using CMS.Shared;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

using Refit;

namespace CMS.Maui;

public partial class App : Application
{
   public App()
   {
      InitializeComponent();

      var services = new ServiceCollection();
      services.AddSingleton<MainPage>();
      services.AddSingleton<CustomerPage>();
      services.AddSingleton<CustomerViewModel>();
      services.AddRefitClient<IMyApiClient>()
          .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:5001"));
      var serviceProvider = services.BuildServiceProvider();

      MainPage = new NavigationPage(serviceProvider.GetService<MainPage>());
   }
}