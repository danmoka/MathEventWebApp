﻿using MathEvent.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MathEvent.Entities
{
    /// <summary>
    /// Контекст данных для работы с базой данных
    /// </summary>
    public class RepositoryContext : IdentityDbContext<ApplicationUser>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // настройка ссылки таблицы на саму себя
            builder.Entity<Event>()
                .HasOne<Event>()
                .WithMany()
                .HasForeignKey(e => e.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<ApplicationUser>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            // подписки
            builder.Entity<Subscription>()
                .HasKey(s => new { s.ApplicationUserId, s.EventId });
            builder.Entity<Subscription>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(s => s.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Subscription>()
                .HasOne<Event>()
                .WithMany()
                .HasForeignKey(s => s.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // менеджмент
            builder.Entity<Management>()
                .HasKey(m => new { m.ApplicationUserId, m.EventId });
            builder.Entity<Management>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(m => m.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Management>()
                .HasOne<Event>()
                .WithMany()
                .HasForeignKey(m => m.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // файлы
            builder.Entity<File>()
                .HasOne<File>()
                .WithMany()
                .HasForeignKey(f => f.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<File>()
                .HasOne<FileOwner>()
                .WithMany()
                .HasForeignKey(f => f.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            // владельцы
            builder.Entity<FileOwner>()
                .HasOne<Event>()
                .WithOne()
                .HasForeignKey<FileOwner>(f => f.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<FileOwner>()
                .HasOne<ApplicationUser>()
                .WithOne()
                .HasForeignKey<FileOwner>(f => f.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
