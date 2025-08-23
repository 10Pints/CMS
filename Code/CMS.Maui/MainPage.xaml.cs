using CMS.Maui.Services;
using CMS.Maui.Views;

namespace CMS.Maui;

public partial class MainPage : ContentPage
{
   private readonly ICustomerService _customerService;

   public MainPage(ICustomerService customerService)
   {
      InitializeComponent();
      _customerService = customerService;
   }

   private async void OnShowCustomersClicked(object sender, EventArgs e)
   {
      // Fetch data
      IEnumerable<Shared.DTOs.CustomerDto> customers = await _customerService.GetAllCustomersAsync();

      // Navigate to CustomersPage, passing the data
      await Navigation.PushAsync(new CustomersPage(customers));
   }
}
