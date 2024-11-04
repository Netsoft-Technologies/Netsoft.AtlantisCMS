using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Models
{
    public class OnlineStringModels
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? MessageId { get; set; }
        public string? Message { get; set; }
        public byte? MessageType { get; set; }
    }
}
