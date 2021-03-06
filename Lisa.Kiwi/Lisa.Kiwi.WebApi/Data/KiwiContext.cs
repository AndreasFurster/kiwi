﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace Lisa.Kiwi.WebApi
{
    public class KiwiContext : IdentityDbContext
    {
        public KiwiContext()
            : base("KiwiContext")
        {
        }

        public DbSet<ReportData> Reports { get; set; }

        public bool HasUnsavedChanges()
        {
            return ChangeTracker.Entries().Any(e => e.State == EntityState.Added
                                                      || e.State == EntityState.Modified
                                                      || e.State == EntityState.Deleted);
        }
    }
}