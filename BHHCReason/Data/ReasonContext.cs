using BHHCReason.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BHHCReason.Data
{
  public class ReasonContext : IdentityDbContext
  {
    public ReasonContext(DbContextOptions<ReasonContext> options)
        : base(options){ }

    public DbSet<Reason> Reason { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Reason>().Property(x => x.UserId)
        .IsRequired().HasMaxLength(40);
    }

  }
}
