using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Dal
{
    public class DTestingTableContentDto
    {
        public int TestId { get; set; }
        public int TestVar1Id { get; set; }
        public string TestVar1Name { get; set; }
        public int TestVar2Id { get;set; }
        public string TestVar2Name { get;set; }
        public string? TestTarget {  get; set; }
        public bool TestResult { get; set; }
    }
}
