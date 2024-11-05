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
    public class COnlinePageComponentsRO : ReadOnlyListBase<COnlinePageComponentsRO, COnlinePageComponentRO>
    {
        [Fetch]
        private void Fetch([Inject] IOnlinePageComponentDal dal, [Inject] IChildDataPortal<COnlinePageComponentRO> portal)
        {
            using (LoadListMode)
            {
                List<DOnlinePageComponentDto> list = null;
                foreach (var item in list)
                {
                    Add(portal.FetchChild(item));
                }
            }
        }
    }
}
