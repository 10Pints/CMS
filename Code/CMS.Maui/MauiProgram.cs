using CMS.Maui.Services;
using CMS.Shared; // Add this for IMyApiClient

using Microsoft.Extensions.Configuration;

//using CMS.Maui.ViewModels; // Add this
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Refit; // Add this for Refit

namespace CMS.Maui;

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
      /*

      builder.Services.AddScoped<ICustomerService>(provider =>
      {
         IConfiguration? config = provider.GetService<IConfiguration>() ?? throw new Exception("E1026: MauiProgram failed to get configuration");
         var connectionString = config.GetConnectionString("DefaultConnection");
         return new CustomerService(connectionString);
      });
      */
      // ✅ ADD THIS - Register Refit client
      builder.Services.AddRefitClient<IMyApiClient>()
          .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:5001/"));

      // Register Services
      builder.Services.AddSingleton<CustomerService>();
      builder.Services.AddTransient<ICustomerService, CustomerService>(); // Register interface too

      // Register ViewModels
      builder.Services.AddTransient<CustomerViewModel>(); // Usually Transient for pages

      // Register Pages
      /*
         AddTransient: Creates a new instance every time it's requested. This is ideal for pages because each navigation to CustomerPage should get a fresh instance.
         AddSingleton: Creates one instance for the entire app. Use this for services like CustomerService.
      */
      builder.Services.AddTransient<MainPage>(); // Usually Transient for pages
      builder.Services.AddTransient<CustomerPage>();

      // Register IServiceProvider ✅ Add this line!
      builder.Services.AddSingleton<IServiceProvider>(sp => sp);
#if DEBUG
      builder.Logging.AddDebug();
#endif

      return builder.Build();
   }
}
