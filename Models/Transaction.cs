using FinancialPortalAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialPortalAPI.Models
{
  public class Transaction
  {
    public int Id { get; set; }
    public int? CategoryItemId { get; set; }
    public int BankAccountId { get; set; }
    public string PortalUserId { get; set; }
    public DateTime Created { get; set; }
    public TransactionType Type { get; set; }
    public string Memo { get; set; }
    public decimal Amount { get; set; }
    public bool IsDeleted { get; set; }
  }
}
