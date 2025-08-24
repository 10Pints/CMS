
using CMS.Maui;
using CMS.Shared.DTOs;

using Microsoft.Maui.Controls;

public partial class CustomerPage : ContentPage
{
   public CustomerPage(CustomerViewModel viewModel)
   {
      InitializeComponent();
      //CustomersList.ItemsSource = customers;
      BindingContext = viewModel;
   }
}