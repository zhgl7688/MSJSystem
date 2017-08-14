using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class MSJDBContext:DbContext
    {
        public MSJDBContext() : base("ConnectionString") { }
        public DbSet<AgentInput> AgentInputs { get; set; }
        public DbSet<BrandsInput> BrandsInputs { get; set; }
    }
}