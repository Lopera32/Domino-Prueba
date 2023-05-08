//using System;
//using System.Collections.Generic;
//using Domino.Core.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.Extensions.Configuration;

//namespace Domino.Infrastructure.Data
//{
//    public partial class DominoContext : DbContext
//    {

     

//        public IConfiguration Configuration { get; }
//        public DominoContext()
//        {
//        }

//       public DominoContext(DbContextOptions<DominoContext> options, IConfiguration configuration)
//            : base(options)
//        {
//            Configuration = configuration;
//        }   public DominoContext(DbContextOptions<DominoContext> options, IConfiguration configuration)
//            : base(options)
//        {
//            Configuration = configuration;
//        }

//        public  DbSet<Core.Entities.Domino> DominoPiece { get; set; }
//        public DbSet<User> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=localhost; Database=Domino;Integrated Security =false; User ID= sa; Password = root");
//                //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=Domino;Integrated Security =true");

//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            List<User> users = new List<User>();
//            users.Add(new User() { Id=1,Name = "Laura", Email = "laura@.com", Lastname = "Gonzalez", Login = "lgonzalez", Password = "123" });

//            modelBuilder.Entity<Domino>(entity =>
//            {
//                //entity.Property(e => e.Id).ValueGeneratedNever();

//                entity.Property(e => e.FirstValue).HasColumnName("firstValue");

//                entity.Property(e => e.SecondValue).HasColumnName("secondValue");

                
//            });

//            modelBuilder.Entity<User>(entity =>
//            {
//                entity.HasKey(e => e.Id);
//                entity.Property(e => e.Name).IsRequired();
//                entity.Property(e => e.Lastname).IsRequired();
//                entity.Property(e => e.Email).IsRequired();
//                entity.Property(e => e.Login).IsRequired();
//                entity.Property(e => e.Password).IsRequired();

//                entity.HasData(users);
//            });

//        }

     
//    }
//}
