using CMS.Shared;
using CMS.Shared.DTOs;

using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMS.shared
{
   public class MyApiClient : IMyApiClient
   {
      private readonly HttpClient _httpClient;

      public MyApiClient(HttpClient httpClient)
      {
         _httpClient = httpClient;
      }

      public async Task<IEnumerable<CustomerDto>> GetCustomers()
      {
         try
         {
            var response = await _httpClient.GetAsync("api/customer");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<CustomerDto>>(content) ?? throw new Exception("E1025: JsonSerializer.Deserialize failed");
         }
         catch (Exception ex)
         {
            // Handle errors appropriately
            Console.WriteLine($"API Error: {ex.Message}");
            throw;
         }
      }

      // Add other methods from IMyApiClient interface here
   }
}