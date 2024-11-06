using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Dal
{
    public interface IOnlinePageDal
    {
        DOnlinePageDto Fetch(int id);
        List<DOnlinePageDto> Fetch();
        void Insert(DOnlinePageDto dto);
        void Update(DOnlinePageDto dto);
        void Delete(int id);
    }
}
