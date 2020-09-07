using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebSysDev.Models;

namespace WebSysDev.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebSysDev.Models.Booking> Booking { get; set; }
        public DbSet<WebSysDev.Models.Customer> Customer { get; set; }
        public DbSet<WebSysDev.Models.Room> Room { get; set; }
    }
}
