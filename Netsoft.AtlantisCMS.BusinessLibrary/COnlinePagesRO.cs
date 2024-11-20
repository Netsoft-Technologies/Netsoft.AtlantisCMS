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
    public class COnlinePagesRO : ReadOnlyListBase<COnlinePagesRO, COnlinePageRO>
    {
        [Fetch]
        private void Fetch([Inject]IOnlinePageDal pageDal, [Inject]IChildDataPortal<COnlinePageRO> pageChildPortal)
        {
            using (LoadListMode)
            {
                List<DOnlinePageDto> list = null;
                list = pageDal.Fetch();
                foreach (var item in list)
                {
                    Add(pageChildPortal.FetchChild(item));
                }
            }
        }
    }
}
