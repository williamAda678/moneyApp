using System;
using MoneyTrack.API.Models;

namespace API.model;

public class Budget
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Category { get; set; }
    public decimal Limit { get; set; }
    public decimal CurrentSpend { get; set; }
    public DateTime Month { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; }
}
