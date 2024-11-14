using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Models
{
    public class OnlineComponentModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? HTMLClassName { get; set; }
        public string? HTMLElementId { get; set; }
        public int? StringContentId { get; set; }
        public int? StylingGroupId { get; set; }
        public List<OnlineComponentStylingPropertyModel> StylingProps { get; set; }
    }

    public class OnlineComponentCreateRequestModel
    {
        public string? Description { get; set; }
        public string? HTMLClassName { get; set; }
        public string? HTMLElementId { get; set; }
        public int? StringContentId { get; set; }
    }
}
