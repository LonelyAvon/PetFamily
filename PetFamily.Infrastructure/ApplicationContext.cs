using Microsoft.EntityFrameworkCore;
using PetFamily.Domain;

namespace PetFamily.Infrastructure;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<Post> Posts => Set<Post>();
}