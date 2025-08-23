using CMS.Maui.Services;

using Microsoft.Extensions.Logging;

namespace CMS.Maui
{
   public static class MauiProgram
   {
      public static MauiApp CreateMauiApp()
      {
         var builder = MauiApp.CreateBuilder();
         builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
               fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
               fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

         builder.Services.AddHttpClient("CMS.Api", client =>
         {
            client.BaseAddress = new Uri("https://localhost:5001/"
                                        //"https://10.0.2.2:57176/"      // when running Android emulator
                                        // or "https://localhost:5001/"  // when running on Windows
                                        );
         });
         builder.Services.AddSingleton<CustomerService>();
#if DEBUG
         builder.Logging.AddDebug();
#endif

         return builder.Build();
      }
   }
}
