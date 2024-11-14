using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Dal
{
    public class DOnlineComponentStylingPropertyDto
    {
        public int StylingPropertyId { get; set; }
        public int ComponentId { get; set; }
        public string Value { get; set; }
        //public string CSSVariable { get; set; }
    }
}
