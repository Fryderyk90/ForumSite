using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;

namespace _9Chan.Data.Repository
{
    public class _9ChanContext : DbContext
    {
        public _9ChanContext(DbContextOptions<_9ChanContext> options)
            : base(options)
        {
        }

        public DbSet<TestClass> TestClasses { get; set; }
    }
}
