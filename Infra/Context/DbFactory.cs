using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Context
{
    public class UserContextFactory : IDesignTimeDbContextFactory<UserContext>
    {
        public UserContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=user;User Id=guilhermebernava;Password=123456;");

            return new UserContext(optionsBuilder.Options);
        }
    }
}

