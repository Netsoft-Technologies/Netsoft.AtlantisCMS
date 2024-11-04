using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Models
{
    public class OnlinePageModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<OnlinePageComponentModel> Components { get; set; }
        public OnlinePageModel()
        {
            Components = new List<OnlinePageComponentModel>(); 
        }
    }
}
