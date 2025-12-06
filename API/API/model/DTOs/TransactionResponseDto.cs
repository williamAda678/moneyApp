using System;

namespace API.model.DTOs;

public class TransactionResponseDto
{
    public Guid Id { get; set; }                  // Transaction ID
    public decimal Amount { get; set; }
    public string Type { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime CreatedAt { get; set; }       // When it was created
    public Guid UserId { get; set; }
}
