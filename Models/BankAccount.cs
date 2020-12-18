using FinancialPortalAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialPortalAPI.Models
{
  public class BankAccount
  {
    public int Id { get; set; }
    public int? HouseholdId { get; set; }
    public string PortalUserId { get; set; }
    public string Name { get; set; }
    public BankAccountType Type { get; set; }
    public decimal StartingBalance { get; set; }
    public decimal CurrentBalance { get; set; }
    public bool isDeleted { get; set; }
  }
}
