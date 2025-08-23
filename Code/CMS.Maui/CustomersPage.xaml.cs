
using CMS.Domain.Entities;
using CMS.Shared.DTOs;
namespace CMS.Maui.Views;

public partial class CustomersPage : ContentPage
{
   public CustomersPage(IEnumerable<CustomerDto> customers)
   {
      InitializeComponent();
      CustomersList.ItemsSource = customers;
   }
}