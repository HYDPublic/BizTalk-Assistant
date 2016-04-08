﻿using Microsoft.Data.Entity;
using DEME.BizTalk.Assistant.Models;

namespace DEME.BizTalk.Assistant.Models.Database.Context
{
    //TODO SQL injection check
    //TODO cross site scripting check
    //TODO cross site request forgery check
    public class AssistantContext : DbContext
    {
        public AssistantContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<BusinessProcess> BusinessProcessDbSet { get; set; }
        public DbSet<Routing> RoutingDbSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
