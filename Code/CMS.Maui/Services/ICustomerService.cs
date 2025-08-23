using CMS.Shared.DTOs;

namespace CMS.Maui.Services;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
}
