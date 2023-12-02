using Microsoft.EntityFrameworkCore;
using Zabota.Models;
public class AppContext : DbContext
{
    public DbSet<Ticket> Tickets { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;

    public AppContext(DbContextOptions<AppContext> options) : base(options) { }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Message>()
    //        .HasOne(t => t.Ticket)
    //        .WithMany(m => m.Message)
    //        .HasForeignKey(x => x.TicketId);
    //}
}

