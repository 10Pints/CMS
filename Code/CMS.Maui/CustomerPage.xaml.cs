
//using CMS.Maui;
//using CMS.Shared.DTOs;
//using Microsoft.Maui.Controls;

namespace CMS.Maui;
public partial class CustomerPage : ContentPage
{
   public CustomerPage(CustomerViewModel viewModel)
   {
      InitializeComponent();
      BindingContext = viewModel;
   }
}