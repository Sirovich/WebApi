using System;
using System.Collections.Generic;
using System.Text;
using Rest.Models;
using Microsoft.EntityFrameworkCore;

namespace Rest.DataLayer.Screens.Contexts
{
    public partial class ScreenContext : DbContext
    {
        public virtual DbSet<Screen> Screens { get; set; }

        public ScreenContext()
        {
            Database.EnsureCreated();
        }

        public ScreenContext(DbContextOptions<ScreenContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Screens;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Screen>(entity =>
            {
                entity.Property(x => x.Height)
                    .IsRequired();

                entity.Property(x => x.Width)
                    .IsRequired();

                entity.Property(x => x.Price)
                    .IsRequired();

                entity.Property(x => x.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
