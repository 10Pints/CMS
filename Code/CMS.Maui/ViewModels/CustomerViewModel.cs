using CMS.Shared; // For IMyApiClient

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System.Collections.ObjectModel;

namespace CMS.Maui;

public partial class CustomerViewModel : ObservableObject
{
   private readonly IMyApiClient _apiClient;

   [ObservableProperty]
   private ObservableCollection<Customer> customers;

   public CustomerViewModel(IMyApiClient apiClient)
   {
      _apiClient = apiClient;
      LoadCustomersCommand = new AsyncRelayCommand(LoadCustomersAsync);
   }

   [RelayCommand]
   private async Task LoadCustomersAsync()
   {
      var customers = await _apiClient.GetCustomers();
      Customers = new ObservableCollection<Customer>(customers);
   }
}
