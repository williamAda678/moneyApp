using System;
using MoneyTrack.API.Models;

namespace API.model;

public class Report
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalExpenses { get; set; }
    public decimal Savings { get; set; }
    public DateTime Month { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; }

}
