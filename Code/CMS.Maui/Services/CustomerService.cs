using System.Net.Http.Json;
using CMS.Shared.DTOs;

namespace CMS.Maui.Services;

public class CustomerService : ICustomerService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CustomerService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
    {
        var client = _httpClientFactory.CreateClient("CMS.Api");
        var result = await client.GetFromJsonAsync<List<CustomerDto>>("api/customers");
        return result ?? [];
    }
}
