using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.DalEfCore
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;
        public DbContext (IConfiguration configuration) 
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public DbSet<OnlinePages_Entity> _OnlinePages { get; set; }
        public DbSet<OnlinePageComponents_Entity> _OnlinePages_Components { get; set; }
        public DbSet<OnlineComponents_Entity> _OnlineComponents {  get; set; }
        public DbSet<OnlineStrings_Entity> _OnlineStrings { get; set; }
        public DbSet<TestingTable_Entity> _TestingTable { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlServer(_connectionString);
    }

    public class OnlinePages_Entity
    {
        [Key]
        public int PageId { get; set; }
        public string PageTitle { get; set; }
        public int? PageOrder { get; set; }
    }
    public class OnlinePageComponents_Entity
    {
        [Key]
        public int ParentPageId { get; set; }
        public string ParentPageTitle { get; set; }
        public int ComponentId { get; set; }
        public string ComponentDesc { get; set; }
        public string ComponentHTMLClassName { get; set; }
        public string ComponentHTMLElementID { get; set; }
    }
    public class OnlineComponents_Entity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string HTMLClassName { get; set; }
        public string HTMLElementId { get; set; }
        public int? StringContentId { get; set; }
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
