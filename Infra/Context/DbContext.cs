using System;
using Infra.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Context
{
    public interface IDbContext { }
    public class UserContext : IdentityDbContext<ApplicationUser, ApplicationRole, String>, IDbContext
    {
        public DbSet<ApplicationUser> users { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

    }
}

