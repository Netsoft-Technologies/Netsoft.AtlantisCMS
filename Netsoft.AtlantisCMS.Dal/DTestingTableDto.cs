using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Dal
{
    public class DTestingTableDto
    {
        public int TestId { get; set; }
        public string TestTitle { get; set; }
        public string TestContent { get; set; }
        public int? TestOrder { get; set; }
        public DateTime? TestTimeCreated { get; set; }
    }
}
