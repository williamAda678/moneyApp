using API.model;

namespace MoneyTrack.API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Transaction> Transactions { get; set; }
        public List<Budget> Budgets { get; set; }
        public List<Report> Reports { get; set; }
    }
}
