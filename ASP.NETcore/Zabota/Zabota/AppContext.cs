using Microsoft.EntityFrameworkCore;
using Zabota.Models;

public class AppContext : DbContext
{
    public DbSet<Ticket> Tickets { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    public AppContext(DbContextOptions<AppContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>()
            .Property(ticket => ticket.Type)
            .HasConversion<string>();
        modelBuilder.Entity<Ticket>()
            .Property(ticket => ticket.Department)
            .HasConversion<string>();
        modelBuilder.Entity<Ticket>()
            .Property(ticket => ticket.Status)
            .HasConversion<string>();
        
        modelBuilder.Entity<Sender>()
            .Property(ticket => ticket.Type)
            .HasConversion<string>();
        
        modelBuilder.Entity<User>()
            .Property(ticket => ticket.Department)
            .HasConversion<string>();
    }
}

