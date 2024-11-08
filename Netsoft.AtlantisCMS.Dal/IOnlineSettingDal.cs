using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Dal
{
    public interface IOnlineSettingDal
    {
        DOnlineSettingDto Fetch(int id);
        List<DOnlineSettingDto> Fetch();
        void Insert(DOnlineSettingDto dtoData);
        void Update(DOnlineSettingDto dtoData);
        void Delete(int id);
    }
}
