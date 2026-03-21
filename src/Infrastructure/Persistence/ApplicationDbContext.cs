using Microsoft.EntityFrameworkCore;
using ScalableRestApi.Domain.Entities;

namespace ScalableRestApi.Infrastructure.Persistence;
//ApplicationDbContext is your database represented as a C# class. 
//It inherits from EF Core's DbContext which gives it all the ability 
//to talk to the database — querying, saving, tracking changes.
public class ApplicationDbContext : DbContext
{
    //Create the EF Core DbContext

    //DbContextOptions carries the database configuration — things like: 
    //Which database provider (SQL Server, PostgreSQL, SQLite)
    //The connection string Any other EF Core settings
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        // The : base(options) just passes those options up to EF Core's DbContext
        //  so it knows how to connect.
    }

    public DbSet<Order> Orders => Set<Order>();
    //DbSet<Order>a queryable collection that maps to a table
    //Ordersthe name EF Core uses for the table
    // Set<Order>()EF Core's built in method to get the DbSet
}