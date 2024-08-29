using Microsoft.EntityFrameworkCore;
using MovTicket.Data;
using MovTicket.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovTicket.Tests
{
    public class MovieTests
    {
        //InMemory
        private DbContextOptions<AppDbContext> GetDbOptions()
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public async Task AddMovie_WritesToDatabase()
        {
            // Arrange
            var options = GetDbOptions();

            // Act
            using (var context = new AppDbContext(options))
            {
                var movie = new Movie
                {
                    m_title = "Inception",
                    m_genre = "Sci-Fi",
                    m_releaseDate = new DateOnly(2010, 7, 16),
                    m_room = "Room A",
                    m_showTime = new DateTime(2023, 12, 1, 19, 0, 0)
                };
                context.Movies.Add(movie);
                await context.SaveChangesAsync();
            }

            // Assert
            using (var context = new AppDbContext(options))
            {
                Assert.Equal(1, await context.Movies.CountAsync());
                var movie = await context.Movies.FirstAsync();
                Assert.Equal("Inception", movie.m_title);
                Assert.Equal("Sci-Fi", movie.m_genre);
                Assert.Equal(new DateOnly(2010, 7, 16), movie.m_releaseDate);
                Assert.Equal("Room A", movie.m_room);
            }
        }
    }
}
