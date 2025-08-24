using Microsoft.Maui.Controls;
using CMS.Maui.Views;

namespace CMS.Maui;

public partial class MainPage : ContentPage
{
   public MainPage()
   {
      InitializeComponent();
      // BindingContext = new CustomersViewModel(); // Add after creating ViewModel
   }

   private async void OnGoToCustomersClicked(object sender, EventArgs e)
   {
      await Navigation.PushAsync(new CustomersPage());
   }
}
