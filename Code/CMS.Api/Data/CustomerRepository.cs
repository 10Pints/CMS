using Microsoft.Data.SqlClient;
using System.Data;
using CMS.Shared.DTOs;

namespace CMS.Api.Data;

public class CustomerRepository
{
   private readonly string _connectionString;

   public CustomerRepository(string connectionString)
   {
      _connectionString = connectionString;
   }

   public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
   {
      var customers = new List<CustomerDto>();

      using var conn = new SqlConnection(_connectionString);
      using var cmd = new SqlCommand("sp_GetAllCustomers", conn)
      {
         CommandType = CommandType.StoredProcedure
      };

      await conn.OpenAsync();

      using var reader = await cmd.ExecuteReaderAsync();
      while (await reader.ReadAsync())
      {
         customers.Add(new CustomerDto
         {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1)
         });
      }

      return customers;
   }

   public async Task<int> AddCustomerAsync(string name)
   {
      using var conn = new SqlConnection(_connectionString);
      using var cmd = new SqlCommand("sp_AddCustomer", conn)
      {
         CommandType = CommandType.StoredProcedure
      };

      cmd.Parameters.AddWithValue("@Name", name);

      await conn.OpenAsync();
      return await cmd.ExecuteNonQueryAsync();
   }
}
