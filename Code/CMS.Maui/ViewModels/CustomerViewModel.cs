using CMS.Shared; // For IMyApiClient
using CMS.Shared.DTOs;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System.Collections.ObjectModel;

namespace CMS.Maui;

public partial class CustomerViewModel : ObservableObject
{
   private readonly IMyApiClient _apiClient;

   [ObservableProperty]
   private ObservableCollection<CustomerDto> customers;

   public CustomerViewModel(IMyApiClient apiClient)
   {
      _apiClient = apiClient;
      LoadCustomersCommand = new AsyncRelayCommand(LoadCustomersAsync);
   }

   [RelayCommand]
   private async Task LoadCustomersAsync()
   {
      var customers = await _apiClient.GetCustomers();
      Customers = new ObservableCollection<CustomerDto>(customers);
   }
}
