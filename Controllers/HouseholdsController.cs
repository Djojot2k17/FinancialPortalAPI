using FinancialPortalAPI.Data;
using FinancialPortalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialPortalAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HouseholdsController : ControllerBase
  {
    private readonly ApiContext _context;
    private readonly IConfiguration _configuration;

    public HouseholdsController(ApiContext context, IConfiguration configuration)
    {
      _context = context;
      _configuration = configuration;
    }
    [HttpGet("GetAllHouseholds")] // this alias overrides the method name
    public IEnumerable<Household> GetAllHouseholds()
    {
      return _context.GetAllHouseholdData(_configuration);
    }
  }
}
