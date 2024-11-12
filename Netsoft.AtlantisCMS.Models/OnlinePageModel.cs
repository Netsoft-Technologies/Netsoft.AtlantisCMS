using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Models
{
    public class OnlinePageModel
    {
        public int PageId { get; set; }
        public string PageTitle { get; set; }
        public int? PageOrder {  get; set; }
        public List<OnlinePageComponentModel> Components { get; set; }
        public OnlinePageModel()
        {
            Components = new List<OnlinePageComponentModel>();
        }
    }

   

}
