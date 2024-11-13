using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Dal
{
    public class DOnlinePageComponentDto
    {
        public int ComponentId { get; set; }
        public int ParentPageId { get; set; }
        public DOnlineComponentStylingPropertyDto ComponentStyling { get; set; }
        //public string ParentPageTitle { get; set; }
        //public string ComponentDesc { get; set; }
        //public string ComponentHTMLClassName { get; set; }
        //public string ComponentHTMLElementID { get; set; }
    }
}
