using FinancialPortalAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

    public List<Household> GetAllHouseholdData(IConfiguration configuration)
    {
      // Get connection string
      var connString = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
      // Open the connection to the db
      connString.Open();

      // get a variable to stuff our data into once it comes back from the db
      var allHouseHolds = new List<Household>();

      // tell npgsql which function to execute on the db
      using (var cmd = new NpgsqlCommand("getallhouseholds", connString))
      {
        // let postgres know that this is a stored procedure
        cmd.CommandType = CommandType.StoredProcedure;

        // Read data from the db
        using (var reader = cmd.ExecuteReader())
        {
          var dataTable = new DataTable();
          dataTable.Load(reader);
          if (dataTable.Rows.Count > 0)
          {
            // Serialize and stuff the data in our variable
            var serializedObjects = JsonConvert.SerializeObject(dataTable);
            allHouseHolds.AddRange((List<Household>)JsonConvert.DeserializeObject(serializedObjects, typeof(List<Household>)));
          }
        }
        connString.Close();
      }
      return allHouseHolds;
    }

  }
}
