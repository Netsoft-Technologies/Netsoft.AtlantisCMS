using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Dal
{
    public interface IOnlineStringDal
    {
        DOnlineStringDto Fetch(int id);
        List<DOnlineStringDto> Fetch();
        void Insert(DOnlineStringDto dto);
        void Update(DOnlineStringDto dto);
        void Delete(int id);
    }
}
