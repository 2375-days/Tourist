using Microsoft.EntityFrameworkCore;
using System;
using Tourist.API.models;

namespace Tourist.API.database
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seeding data  初始化种子数据
            modelBuilder.Entity<TouristRoute>().HasData(new TouristRoute()
            {
                Id = Guid.NewGuid(),
                Title = "测试数据",
                Description = "测试数据2",
                OriginalPrice = 0,
                CreateTime = DateTime.UtcNow
            });

        }

        public DbSet<TouristRoute> TouristRoutes;
        public DbSet<TouristRoutePicture> TouristRoutesPictures;
    }
}
