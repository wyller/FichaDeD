using System;
using DAL.Model;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace DAL.Context
{
    public class Contexto : DbContext
    {
        public DbSet<Player> Player { get; set; }
        public DbSet<Skill> Skill { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=postgres;User Id=admin;Password=123456;");
        }
    }
}