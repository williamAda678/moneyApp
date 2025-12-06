using System.Security.Claims;
using API.Helper;
using API.model;
using API.model.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyTrack.API.Data;
using MoneyTrack.API.Models;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly MoneyTrackContext _context;

        // Constructor: inject DbContext
        public TransactionsController(MoneyTrackContext context)
        {
            _context = context;
        }

        // GET: api/transactions
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var userId = GetUserIdFromToken();
            var transactions = await _context.Transactions
               .Where(t => t.UserId == userId)
               .ToListAsync();
            // 1. Retrieve all transactions from DB
            // 2. Optionally, filter by user (once auth is added)
            return Ok(transactions.ToResponseDto());
        }

        // GET: api/transactions/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(Guid id)
        {
            var userId = GetUserIdFromToken();
            var transactions = await _context.Transactions.Where(x => x.UserId == userId && x.Id == id).FirstOrDefaultAsync();

            if (transactions == null) return NotFound();
            // 1. Find transaction by id
            // 2. Return 404 if not found
            return Ok(transactions.ToResponseDto());
        }

        // POST: api/transactions
        [HttpPost]
        public async Task<IActionResult> CreateTransaction(TransactionCreateDto dto)
        {
            var userId = GetUserIdFromToken();
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                Amount = dto.Amount,
                Type = dto.Type,
                Category = dto.Category,
                Description = dto.Description,
                Date = dto.Date,
                CreatedAt = DateTime.UtcNow,
                UserId = userId
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();


            // 1. Validate input (amount > 0, type = Income/Expense, category not empty)
            // 2. Create new Transaction entity
            // 3. Save to database
            // 4. Return CreatedAtAction with new transaction
            return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.Id }, transaction.ToResponseDto());
        }

        // PUT: api/transactions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(Guid id, TransactionUpdateDto dto)
        {
            var userId = GetUserIdFromToken();
            var transactions = await _context.Transactions.Where(x => x.UserId == userId && x.Id == id).FirstOrDefaultAsync();

            if (transactions == null) return NotFound();

            transactions.Amount = dto.Amount;
            transactions.Type = dto.Type;
            transactions.Category = dto.Category;
            transactions.Description = dto.Description;
            transactions.Date = dto.Date;


            await _context.SaveChangesAsync();
            // 1. Find existing transaction by id
            // 2. Return 404 if not found
            // 3. Update fields
            // 4. Save changes
            return NoContent();
        }

        // DELETE: api/transactions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(Guid id)
        {

            var userId = GetUserIdFromToken();
            var transactions = await _context.Transactions.Where(x => x.UserId == userId && x.Id == id).FirstOrDefaultAsync();

            if (transactions == null) return NotFound();

            _context.Remove(transactions);
            await _context.SaveChangesAsync();
            // 1. Find transaction by id
            // 2. Return 404 if not found
            // 3. Remove from database
            // 4. Save changes
            return NoContent();
        }

        private Guid GetUserIdFromToken()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Guid.Parse(userIdString);
        }
    }
}
