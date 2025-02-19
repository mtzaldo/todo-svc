using Microsoft.EntityFrameworkCore;

namespace Todo.Broker.Domain.Entities;
public class DataContext : DbContext
{
    private readonly IConfiguration configuration;

    public DataContext(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(this.configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<TodoEntity> Todos { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
}