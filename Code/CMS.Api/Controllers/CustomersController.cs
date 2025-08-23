using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CMS.Api.Data;
using CMS.Shared.DTOs;

namespace CMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize] // 🔒 all endpoints require JWT
public class CustomersController : ControllerBase
{
   private readonly CustomerRepository _repo;

   public CustomersController(CustomerRepository repo)
   {
      _repo = repo;
   }

   [HttpGet]
   public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
   {
      var customers = await _repo.GetAllCustomersAsync();
      return Ok(customers);
   }

   [HttpPost]
   public async Task<ActionResult> Add([FromBody] CustomerDto dto)
   {
      if (string.IsNullOrWhiteSpace(dto.Name))
         return BadRequest("Customer name required");

      var rows = await _repo.AddCustomerAsync(dto.Name);
      return rows > 0 ? Ok() : StatusCode(500, "Insert failed");
   }
}
