using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Models
{
    public class OnlineComponentStylingPropertyModel
    {
        public int StylingPropId { get; set; }
        public int ParentCompId { get; set; }
        public string StyleValue { get; set; }
    }
}
