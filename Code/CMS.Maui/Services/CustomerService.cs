using System.Net.Http.Json;
using CMS.Shared.DTOs;

namespace CMS.Maui.Services;

public class CustomerService : ICustomerService
{
    private readonly HttpClient _httpClient;

    public CustomerService(IHttpClientFactory httpClientFactory)
    {
         _httpClient = httpClientFactory.CreateClient("CMS.Api");
   }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<CustomerDto>>("api/customers");
        return result ?? [];
    }
}
