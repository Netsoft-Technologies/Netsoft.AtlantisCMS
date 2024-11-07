using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Dal
{
    public interface IOnlineComponentDal
    {
        DOnlineComponentDto Fetch(int id);
        List<DOnlineComponentDto> Fetch();
        void Insert(DOnlineComponentDto dtoData);
        void Update(DOnlineComponentDto dtoData);
        void Delete(int id);
    }
}
