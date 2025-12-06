using MoneyTrack.API.Models;

namespace API.model;

public class Transaction
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public string Type { get; set; }  // "Income" or "Expense"
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; }
}
