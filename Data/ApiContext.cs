using FinancialPortalAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialPortalAPI.Data
{
  public class ApiContext : DbContext
  {
    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {
    }

    // TODO: make all methods that getalldbscripts()
    public List<PortalUser> GetAllUsersAsync(string conn)
    {
      var connString = new NpgsqlConnection(conn);
      connString.Open();
      using var command = new NpgsqlCommand("getallusers", connString);
      using NpgsqlDataReader reader = command.ExecuteReader();

      var dataTable = new DataTable();
      dataTable.Load(reader);
      return (List<PortalUser>)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(dataTable), typeof(List<PortalUser>));
    }

  }
}
