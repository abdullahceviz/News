using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class NewsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=News;Trusted_Connection=true");
        }
        public override int SaveChanges()
        {
            //ChangeTrackerdaki kayıtları dön
            ChangeTracker.Entries().ToList().ForEach(entry =>
            {
                //trackerdaki kaydın state added ise
                if(entry.State == EntityState.Added)
                {
                    //IEntity türünde ise entity değişkenine ata
                    if (entry.Entity is IEntity entiy)
                    {
                        //yani yeni ekliyorsa oluşturma tarihini tek bir yerden yaptık.
                        entiy.CreatedDate = DateTime.Now;
                    }
                }
            });
            return base.SaveChanges();
        }
        public DbSet<News> News { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
