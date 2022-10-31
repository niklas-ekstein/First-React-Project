using System;
using Microsoft.EntityFrameworkCore;

namespace ReactBackend.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Post>().HasData(
                   new Post() { PostId = 1, Title = "Seed 1", Content = "Seed data 1" },
                   new Post() { PostId = 2, Title = "Seed 2", Content = "Seed data 2" },
                   new Post() { PostId = 3, Title = "Seed 3", Content = "Seed data 3" }
            );
        }
    }
}

