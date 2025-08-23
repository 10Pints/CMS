//using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Hosting;
//using Microsoft.Maui.Hosting;

namespace CMS.Maui;
public partial class App : Application
{
   public App()
   {
      InitializeComponent();

      MainPage = new NavigationPage(new MainPage());
   }
}