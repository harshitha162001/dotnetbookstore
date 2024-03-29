﻿using BulkyWebRezorproject.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRezorproject.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)/*ctor will pass to the Dbcontext class base(options)*/
        {

        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "action", DisplayOrder = 1 },
                 new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                  new Category { Id = 3, Name = "History", DisplayOrder = 3 }
         );
        }
    }
}
