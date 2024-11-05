using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Models
{
    public class TestingTableModel
    {
        public int TestId { get; set; }
        public string TestTitle { get; set; }
        public string TestContent { get; set; }
        public int? TestOrder { get; set; }
        public DateTime? TestDate { get; set; }

        //public List<TestingContentModel> TestingContents { get; set; }
        //public TestingTableModel()
        //{
        //    TestingContents = new List<TestingContentModel>();
        //}
    }
}
