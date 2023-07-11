using Microsoft.EntityFrameworkCore;
using ToDoApplication.Domain.Entity;

namespace ToDoApplication.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
        Database.EnsureDeleted();
    }
    
    public DbSet<TaskEntity> Tasks { get; set; }
}