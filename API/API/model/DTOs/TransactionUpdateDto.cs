using System;

namespace API.model.DTOs;

public class TransactionUpdateDto
{
    public decimal Amount { get; set; }
    public string Type { get; set; }        // "Income" or "Expense"
    public string Category { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
}
