using Microsoft.EntityFrameworkCore;
using RotaViagem.Domain.Models;
using System;

namespace RotaViagem.Infra.Repository.Context
{
    public class RotaContext : DbContext
    {
        public RotaContext(DbContextOptions<RotaContext> options) : base(options)
        {
        }
        public DbSet<Rota> Rota { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Rota>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
