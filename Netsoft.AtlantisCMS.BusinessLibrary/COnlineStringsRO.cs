using Csla;
using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.BusinessLibrary
{
    [Serializable]
    public class COnlineStringsRO : ReadOnlyListBase<COnlineStringsRO, COnlineStringRO>
    {
        [Fetch]
        private void Fetch([Inject] IOnlineStringDal stringDal, [Inject] IChildDataPortal<COnlineStringRO> stringChildPortal)
        {
            using (LoadListMode)
            {
                List<DOnlineStringDto> list = null;
                list = stringDal.Fetch();
                foreach (var item in list)
                {
                    Add(stringChildPortal.FetchChild(item));
                }
            }
        }
    }
}
