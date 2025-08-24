using Microsoft.Maui.Controls;
//using CMS.Maui.Views;

namespace CMS.Maui;

public partial class MainPage : ContentPage
{
   public MainPage()
   {
      InitializeComponent();
      //BindingContext = new CustomerViewModel(); // Add after creating ViewModel
   }

   private async void OnGoToCustomersClicked(object sender, EventArgs e)
   {
      // MAUI will automatically resolve CustomerPage with its dependencies
      var customerPage = Handler?.MauiContext?.Services.GetService<CustomerPage>() ?? throw new Exception("E1023: could not resolve CustomerPage");
      await Navigation.PushAsync(customerPage);
   }
}
