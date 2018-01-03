using Domain.Varliklar;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using VeriErisim.Context.Mapler;

namespace VeriErisim.Context
{
    public class OkulContext : DbContext
    {
        static OkulContext()
        {
            AutoMapperConfig.RegisterMappings();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-8BGLM9G\\SQLFATIH;Database=ReactMobx;Trusted_Connection=True;MultipleActiveResultSets = true");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new BolumMap(modelBuilder.Entity<Bolum>());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        public DbSet<Bolum> Bolumler { get; set; }

    }








}