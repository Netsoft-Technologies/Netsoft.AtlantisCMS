using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Dal
{
    public class DOnlinePageComponentDto
    {
        public int PageId { get; set; }
        public string PageTitle { get; set; }
        public int ComponentId { get; set; }
        public string ComponentDescription { get; set; }
        public string ComponentHTMLClassName { get; set; }
        public string ComponentHTMLElementId { get; set; }
    }
}
