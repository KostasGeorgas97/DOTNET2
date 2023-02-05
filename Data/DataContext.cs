using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DOTNET2.Data 
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _config;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration config) : base(options) //constructor //base is the parent class //options is the parameter//DbContextOptions is the type of the parameter
        {
            _config = config; //config is the parameter//IConfiguration is the type of the parameter // Constructor
        }
        public DbSet<Country> Countries => Set<Country>(); //DbSet is a class that represents a collection of entities in the context //Set is a method that returns a DbSet //Country is the type of the DbSet
    }
}