using PracaDyplomowa.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace PracaDyplomowa.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            : base(options)
        {

        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        internal object FirstOrDefault()
        {
            throw new NotImplementedException();
        }
    }
}
