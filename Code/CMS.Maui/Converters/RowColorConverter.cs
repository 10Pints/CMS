//using Microsoft.Maui.Controls;

using System.Globalization;

namespace CMS.Maui.Converters
{
   public class RowColorConverter : IValueConverter
   {
      public Color EvenColor { get; set; } = Colors.White;
      public Color OddColor { get; set; } = Color.FromArgb("#F8F9FA");

      public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
      {
         // If we can't get the index, return default color
         if (value is not null && parameter is BindingContextWrapper wrapper)
         {
            return wrapper.Index % 2 == 0 ? EvenColor : OddColor;
         }

         return EvenColor;
      }

      public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
      {
         throw new NotImplementedException();
      }
   }

   // Helper class to pass index
   public class BindingContextWrapper
   {
      public int Index { get; set; }
      public object? Item { get; set; }
   }
}