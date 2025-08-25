using CMS.Shared.DTOs;
using Refit;


namespace CMS.Shared;

public interface IMyApiClient
{
   [Get("/api/customer")]
   Task<IEnumerable<CustomerDto>> GetCustomers();
}

