using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Assignment4.Core;
using System;
using Assignment4.Entities;
namespace Assignment4.Entities

{
    public class KanbanContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql($"Host=localhost;Database=lecture4;Username=postgres;Password=cxr48ges");

        protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder
            .Entity<Task>()
            .Property(e => e.State)
            .HasConversion(
                v => v.ToString(),
                v => (State)Enum.Parse(typeof(State), v));
        }  

    }
}
