using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookManager.Models
{
    public partial class book : DbContext
    {
        public book()
            : base("name=book")
        {
        }

        public virtual DbSet<DanhSach> DanhSaches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhSach>()
                .Property(e => e.Author)
                .IsFixedLength();

            modelBuilder.Entity<DanhSach>()
                .Property(e => e.Title)
                .IsFixedLength();

            modelBuilder.Entity<DanhSach>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<DanhSach>()
                .Property(e => e.Image)
                .IsFixedLength();
        }
    }
}
