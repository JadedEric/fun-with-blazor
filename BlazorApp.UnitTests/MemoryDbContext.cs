using BlazorApp.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorApp.UnitTests
{
    public abstract class MemoryDbContext : IDisposable
    {
        private const string InMemoryConnectionString = "Data Source=:memory:";
        private readonly SqliteConnection _connection;

        protected readonly BlazorAppDbContext _context;

        protected MemoryDbContext()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();

            var options = new DbContextOptionsBuilder<BlazorAppDbContext>()
                .UseSqlite(_connection)
                .Options;

            _context = new BlazorAppDbContext(options);
            _context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
