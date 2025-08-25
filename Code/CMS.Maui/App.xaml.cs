//using CMS.Shared;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Maui.Controls;

namespace CMS.Maui;

public partial class App : Application
{
   public App(IServiceProvider serviceProvider)
   {
      InitializeComponent();

      // Clean and simple - just set the main page
      // Services are already configured in MauiProgram.cs
      MainPage = new NavigationPage(serviceProvider.GetRequiredService<MainPage>());
   }
}