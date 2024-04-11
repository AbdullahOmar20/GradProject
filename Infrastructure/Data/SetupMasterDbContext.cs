//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Infrastructure.Data.Configuration;
using Core.Entites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;



namespace Infrastructure.Data
{
    public class SetupMasterDbContext : DbContext
    {

       
        public SetupMasterDbContext(DbContextOptions<SetupMasterDbContext> options) : base(options)
        {
        }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<RAM> RAMs{ get; set; }
        public DbSet<SSD> SSDs { get; set; }
        public DbSet<HDD> HDDs { get; set; }
        public DbSet<CPUCooler> CPUCoolers { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<PowerSupply> PowerSupplies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Motherboard> motherboards{get;set;}
        
    }}