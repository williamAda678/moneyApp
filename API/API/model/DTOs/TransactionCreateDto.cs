using System;

namespace API.model.DTOs;

public class TransactionCreateDto
{
    public decimal Amount { get; set; }           // Transaction amount
    public string Type { get; set; }              // "Income" or "Expense"
    public string Category { get; set; }          // e.g., "Food", "Salary"
    public string Description { get; set; }       // Optional notes
    public DateTime Date { get; set; }            // Date of the transaction
}
