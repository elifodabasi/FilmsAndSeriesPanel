using Abp.Localization;
using Abp.Zero.EntityFrameworkCore;
using FilmPanel.Authorization.Roles;
using FilmPanel.Authorization.Users;
using FilmPanel.Models;
using FilmPanel.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmPanel.EntityFrameworkCore
{
   public class FilmPanelDbContext : AbpZeroDbContext<Tenant, Role, User, FilmPanelDbContext>
    {

        public virtual DbSet<FilmAndSeries> FilmAndSeries { get; set; }
        public virtual DbSet<Vote> Vote { get; set; }
        public FilmPanelDbContext(DbContextOptions<FilmPanelDbContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationLanguageText>()
                .Property(p => p.Value)
                .HasMaxLength(100); // any integer that is smaller than 10485760
        }


    }
}
