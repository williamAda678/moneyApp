using System;
using API.model;
using API.model.DTOs;

namespace API.Helper;


public static class TransactionMapper
{
    // Map entity to response DTO
    public static TransactionResponseDto ToResponseDto(this Transaction transaction)
    {
        return new TransactionResponseDto
        {
            Id = transaction.Id,
            Amount = transaction.Amount,
            Type = transaction.Type,
            Category = transaction.Category,
            Description = transaction.Description,
            Date = transaction.Date,
            CreatedAt = transaction.CreatedAt,
            UserId = transaction.UserId
        };
    }
    // Optional: map a list of transactions
    public static IEnumerable<TransactionResponseDto> ToResponseDto(this IEnumerable<Transaction> transactions)
    {
        return transactions.Select(t => t.ToResponseDto());
    }
}



