using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Models
{
    public class OnlinePageComponentModel
    {
        public int ComponentId { get; set; }
        public int ParentPageId { get; set; }
        public string ComponentDescription { get; set; }
        public string ComponentHTMLClassName { get; set; }
        public string ComponentHTMLElementId { get; set; }
    }
}
