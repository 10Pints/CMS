using CMS.Domain.Entities;
using CMS.Shared; // For IMyApiClient
using CMS.Shared.DTOs;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System.Collections.ObjectModel;

namespace CMS.Maui;

public partial class CustomerViewModel : ObservableObject
{
   private readonly IMyApiClient _apiClient;

   private ObservableCollection<CustomerDto> _customers;

   //[ObservableProperty]
   public ObservableCollection<CustomerDto> Customers
   {
      get => _customers;
      set => SetProperty(ref _customers, value);
   }

   public CustomerViewModel(IMyApiClient apiClient)
   {
      _customers = new ObservableCollection<CustomerDto>();
      _apiClient = apiClient;
      //LoadCustomersCommand = new AsyncRelayCommand(LoadCustomersAsync);
   }

   [RelayCommand]
   private async Task LoadCustomersAsync()
   {
      try
      {
         var customers = await _apiClient.GetCustomers();
         Customers = new ObservableCollection<CustomerDto>(customers);
      }
      catch (Exception ex)
      {
         await Shell.Current.DisplayAlert("Error", $"Failed to load customers: {ex.Message}", "OK");
      }
   }
}
