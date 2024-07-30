using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseHackathon.Models
{
    [Table("Expense")]
    public class Expense
    {
        [Key]
        public int SerialNo { get; set; }
        public string Description { get; set; }
        public DateTime Date {  get; set; }
        public float Amount { get; set; }
    }

    public class ExpenseDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public ExpenseDbContext(DbContextOptions options) : base(options) { }
    }
}
