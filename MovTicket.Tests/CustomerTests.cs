using Microsoft.EntityFrameworkCore;
using MovTicket.Data;
using MovTicket.Models.Entities;
using System.Threading.Tasks;
using Xunit;

namespace MovTicket.Tests;


public class CustomerTests
{
    private DbContextOptions<AppDbContext> GetDbOptions()
    {
        return new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
    }

    [Fact]
    public async Task AddCustomer_WritesToDatabase()
    {
        // Arrange
        var options = GetDbOptions();

        // Act
        using (var context = new AppDbContext(options))
        {
            var customer = new Customer
            {
                c_name = "John Doe",
                c_adress = "1234 Elm St",
                c_email = "john.doe@example.com",
                c_phone = "555-555-5555",
                c_subscription = true
            };
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
        }

        // Assert
        using (var context = new AppDbContext(options))
        {
            Assert.Equal(1, await context.Customers.CountAsync());
            var customer = await context.Customers.FirstAsync();
            Assert.Equal("John Doe", customer.c_name);
            Assert.Equal("1234 Elm St", customer.c_adress);
            Assert.Equal("john.doe@example.com", customer.c_email);
            Assert.Equal("555-555-5555", customer.c_phone);
            Assert.True(customer.c_subscription);
        }
    }

    [Fact]
    public async Task EditCustomer_UpdatesDatabase()
    {
        // Arrange
        var options = GetDbOptions();

        using (var context = new AppDbContext(options))
        {
            var customer = new Customer
            {
                c_name = "John Doe",
                c_adress = "1234 Elm St",
                c_email = "john.doe@example.com",
                c_phone = "555-555-5555",
                c_subscription = true
            };
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
        }

        // Act
        using (var context = new AppDbContext(options))
        {
            var customer = await context.Customers.FirstAsync();
            customer.c_name = "Jane Doe";
            customer.c_phone = "555-555-5556";
            context.Customers.Update(customer);
            await context.SaveChangesAsync();
        }

        // Assert
        using (var context = new AppDbContext(options))
        {
            var customer = await context.Customers.FirstAsync();
            Assert.Equal("Jane Doe", customer.c_name);
            Assert.Equal("555-555-5556", customer.c_phone);
        }
    }

    //[Fact]
    //public async Task DeleteCustomer_RemovesFromDatabase()
    //{
    //    // Arrange
    //    var options = GetDbOptions();

    //    using (var context = new AppDbContext(options))
    //    {
    //        var customer = new Customer
    //        {
    //            c_name = "John Doe",
    //            c_adress = "1234 Elm St",
    //            c_email = "john.doe@example.com",
    //            c_phone = "555-555-5555",
    //            c_subscription = true
    //        };
    //        context.Customers.Add(customer);
    //        await context.SaveChangesAsync();
    //    }

    //    // Act
    //    using (var context = new AppDbContext(options))
    //    {
    //        var customer = await context.Customers.FirstAsync();
    //        context.Customers.Remove(customer);
    //        await context.SaveChangesAsync();
    //    }

    //    // Assert
    //    using (var context = new AppDbContext(options))
    //    {
    //        Assert.Equal(0, await context.Customers.CountAsync());
    //    }
    //}
}