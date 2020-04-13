using Microsoft.EntityFrameworkCore;

namespace MRS_Store.Models
{
    public class StoreDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Account> Account{ get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Register> Register { get; set; }
        public DbSet<Shift> Shift { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<TransactionEntry> TransactionEntry { get; set; }
        public DbSet<TransactionPayment> TransactionPayment { get; set; }

        public StoreDbContext(DbContextOptions options) : base(options) 
        {

        }
        public StoreDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
