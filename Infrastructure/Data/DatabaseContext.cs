using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DatabaseContext : DbContext
    {

        //Pass in a connection strng or db name via injection
        //https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/

        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }


        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();

        }

        public virtual DbSet<LocalTorrent> LocalTorrents { get; set; }

    }
}
