﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;
using Entities;

namespace Data
{ 

   public class ServiceContext : DbContext{
    public ServiceContext( DbContextOptions<ServiceContext> Options) : base (Options) { }
    public DbSet<Productos> Productos { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Categorias> Categorias { get; set; }
    public DbSet<Compras> Compras { get; set; }

    public DbSet<DetallesCompras> DetallesCompras { get; set; }
    public DbSet<Roll> Roll { get; set; }

    public DbSet<Tipos> Tipos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Productos>(entity =>
            {
                entity.ToTable("Productos");
            });
            builder.Entity<Clientes>(entity =>
            {
                entity.ToTable("Clientes");
            });
            builder.Entity<Categorias>(entity =>
            {
                entity.ToTable("Categorias");
            });
            builder.Entity<Compras>(entity =>
            {
                entity.ToTable("Compras");
            });
            builder.Entity<DetallesCompras>(entity =>
            {
                entity.ToTable("DetallesCompras");
            });

            builder.Entity<Roll>(entity =>
            {
                entity.ToTable("Roll");
            });
            builder.Entity<Tipos>(entity =>
            {
                entity.ToTable("Tipos");
            });
        }

    }
   
    public class ServiceContextFactory : IDesignTimeDbContextFactory<ServiceContext>
    {
        public ServiceContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false, true);
            var config = builder.Build();
            var connectionString = config.GetConnectionString("ServiceContext");
            var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ServiceContext"));
            return new ServiceContext(optionsBuilder.Options);
        }
    }
}




