﻿using Microsoft.EntityFrameworkCore;
using TP_CS.Business.Models;

namespace TP_CS.Data.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        
        public DbSet<User>? Users { get; set; }
        public DbSet<UserTask>? Tasks { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTask>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(t => t.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}