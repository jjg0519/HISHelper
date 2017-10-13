﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Working.Models.DataModel
{

    public class WorkingDbContext : DbContext
    {
        public WorkingDbContext(DbContextOptions<WorkingDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<WorkItem> WorkItem { get; set; }

     

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(m => m.ID);
            builder.Entity<WorkItem>().HasKey(m => m.ID);          
            base.OnModelCreating(builder);
        }
    }
}