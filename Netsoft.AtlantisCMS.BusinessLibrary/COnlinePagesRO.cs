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
        private void Fetch([Inject] IOnlinePagesDal dal, [Inject] IChildDataPortal<COnlinePageRO> portal) 
        {
            using (LoadListMode)
            {
                List<DOnlinePageDto> list = null;
                list = dal.Fetch();
                foreach (var item in list)
                {
                    this.Add(portal.FetchChild(item));
                }
            }
        }
    }
}
