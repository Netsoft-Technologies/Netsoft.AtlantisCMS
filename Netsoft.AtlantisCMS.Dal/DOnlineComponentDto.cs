using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Dal
{
    public class DOnlineComponentDto
    {
        public int CompId { get; set; }
        public string Description { get; set; }
        public string HTMLClassName { get; set; }
        public string HTMLElementId { get; set; }
        public int? StringContentId { get; set; }
        public int? StylingGroupId { get; set; }
    }
}
