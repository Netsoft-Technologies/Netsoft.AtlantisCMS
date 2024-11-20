using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Dal
{
    public class DOnlinePageDto
    {
        public int PageId { get; set; }
        public string PageTitle { get; set; }
        public int? PageOrder {  get; set; }

        // Not sure if needed
        public List<DOnlinePageComponentDto>? Components { get; set; }
    }
}
