//using Microsoft.EntityFrameworkCore;
using CMS.Domain;
using CMS.Shared.DTOs;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

using System.Data;

namespace CMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
   private string? _connectionString;

   public CustomerController(IConfiguration configuration)
   {
      _connectionString = configuration.GetConnectionString("DefaultConnection");
   }

   [HttpGet]
   public async Task<ActionResult<List<CustomerDto>>> GetCustomers()
   {
      var customers = new List<CustomerDto>();

      using (var connection = new SqlConnection(_connectionString))
      {
         await connection.OpenAsync();
         using (var command = new SqlCommand("sp_GetAllCustomers", connection))
         {
            command.CommandType = CommandType.StoredProcedure;
            using (var reader = await command.ExecuteReaderAsync())
            {
               while (await reader.ReadAsync())
               {
                  customers.Add(new CustomerDto
                  {
                     Id = reader.GetInt32("Id"),
                     Name = reader.GetString("Name")
                  });
               }
            }
         }
      }

      return Ok(customers);
   }
}
