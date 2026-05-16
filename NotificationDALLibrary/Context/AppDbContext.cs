using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NotificationModelLibrary.Models;

namespace NotificationDALLibrary;

public class AppDbContext : DbContext
{
    public DbSet<User> Users {get; set;}
    public DbSet<Notification> Notifications {get; set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(e=>e.Id);
        modelBuilder.Entity<Notification>().HasOne(n => n.User)
                    .WithMany(u => u.Notifications)
                    .HasForeignKey(n => n.UserId);
    }
}

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql("host=localhost;Port=5432;Username=murasaki;Password=123456;Database=notificationdb");
        return new AppDbContext(optionsBuilder.Options);
    }
}