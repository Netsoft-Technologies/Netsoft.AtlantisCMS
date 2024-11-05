﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.DalEfCore
{
    public class TicketContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;
        public TicketContext (IConfiguration configuration) 
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public DbSet<OnlineStrings_Entity> _OnlineStrings { get; set; }
        public DbSet<TestingTable_Entity> _TestingTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlServer(_connectionString);
    }

    public class OnlinePages_Entity
        {
            [Key]
            public int Id { get; set; }
            public string Title { get; set; }
            public int? PageOrder { get; set; }
        }
    public class OnlineStrings_Entity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int? MessageId { get; set; }
        public string Message { get; set; }
        public byte? MessageType { get; set; }
    }
    public class TestingTable_Entity
    {
        [Key]
        public int TestId { get; set; }
        public string TestTitle { get; set; }
        public string TestContent { get; set; }
        public int? TestOrder { get; set; }
        public DateTime? TestTimeCreated { get; set; }
    }
}
