using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyConsoleAppTest
{
    public class AppDbContext: DbContext
    {
        public Guid Guid1 { get; set; }

        protected AppDbContext(DbContextOptions options) : base(options) 
        { 
            Guid1 = Guid.NewGuid(); 
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : this((DbContextOptions)options)
        {
        }

        //people
        public DbSet<Person> Person { get; set; }
    }

    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
