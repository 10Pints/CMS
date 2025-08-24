using CMS.Maui.Services;
using CMS.Shared; // For IMyApiClient
//using CMS.Maui.ViewModels; // Add this
using Microsoft.Extensions.DependencyInjection;
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

         // Configure HttpClient
         builder.Services.AddHttpClient("CMS.Api", client =>
         {
            client.BaseAddress = new Uri("https://localhost:5001/"
                                        //"https://10.0.2.2:57176/"      // when running Android emulator
                                        // or "https://localhost:5001/"  // when running on Windows
                                        );
         });

         // Register Services
         builder.Services.AddSingleton<CustomerService>();

         // Register ViewModels
         builder.Services.AddTransient<CustomerViewModel>(); // Usually Transient for pages

         // Register Pages
         builder.Services.AddTransient<MainPage>(); // Usually Transient for pages
#if DEBUG
         builder.Logging.AddDebug();
#endif

         return builder.Build();
      }
   }
}
