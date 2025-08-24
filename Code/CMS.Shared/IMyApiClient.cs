using CMS.Shared.DTOs;

using Refit;

namespace CMS.Shared;

public interface IMyApiClient
{
   [Get("/api/customers")]
   Task<List<CustomerDto>> GetCustomers();
}

