using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class RepositoryDBContext: Microsoft.EntityFrameworkCore.DbContext
{
    public RepositoryDBContext(DbContextOptions<RepositoryDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Box>().Property(f => f.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Manager>().Property(m => m.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Manager>().HasIndex(m => m.Username).IsUnique();
    }

    public DbSet<Box> BoxTable
    {
        get;
        set;
    }
    
    public DbSet<Manager> ManagerTable
    {
        get;
        set;
    }
    
}