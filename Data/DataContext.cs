using Microsoft.EntityFrameworkCore;
using authentication_api.Models;

namespace authentication_api.Data;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options): base(options)
  {
  }

  public DbSet<User> Users { get; set; } = null!;
}