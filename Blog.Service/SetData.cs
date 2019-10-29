using Blog.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Service
{
    public class SetData:DbContext
    {
        public SetData()
        {
            Database.EnsureCreated();
        }
        public SetData(DbContextOptions<SetData> options): base(options)
        {
            Database.EnsureCreated();//自动创建数据库
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                Id = 1,
                Account = "admin",
                Password = "admin",
                Email = "admin@admin.com",
                NickName = "admin"
            });

            modelBuilder.Entity<BlogInfo>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x=>x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<BContent>()
                .HasOne(x => x.Blog)
                .WithOne(x => x.Content)
                .HasForeignKey<BContent>(x => x.BlogId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<BlogInfo> Blogs { get; set; }
        public DbSet<BContent> BContents { get; set; }
        public DbSet<Diary> Diarys { get; set; }
    }
}
