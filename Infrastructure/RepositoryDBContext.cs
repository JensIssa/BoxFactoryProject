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
        //  modelBuilder.Entity<Manager>().Property(f => f.Id).ValueGeneratedOnAdd();
    }

    public DbSet<Box> BoxTable
    {
        get;
        set;
    }
/**
    public DbSet<Manager> ManagerTable
    {
        get;
        set;
    }
    */
}