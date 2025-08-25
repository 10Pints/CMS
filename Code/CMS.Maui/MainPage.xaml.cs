using Microsoft.Maui.Controls;

namespace CMS.Maui;

public partial class MainPage : ContentPage
{
   private readonly IServiceProvider _serviceProvider;

   public MainPage(IServiceProvider serviceProvider)
   {
      InitializeComponent();
      //BindingContext = new CustomerViewModel(); // Add after creating ViewModel
      _serviceProvider = serviceProvider;
   }

   private async void OnGoToCustomersClicked(object sender, EventArgs e)
   {
      // MAUI will automatically resolve CustomerPage with its dependencies
      IViewHandler? handler = Handler;
      var mauiContext = handler?.MauiContext;
      CustomerPage? customerPage = mauiContext?.Services.GetService<CustomerPage>();

      // customerPage is null here at the moment -
      if (customerPage == null)
         throw new Exception("E1023: could not resolve CustomerPage");

      await Navigation.PushAsync(customerPage);
   }
}
