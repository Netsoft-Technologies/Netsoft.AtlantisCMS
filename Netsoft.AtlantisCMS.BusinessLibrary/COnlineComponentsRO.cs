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
    public class COnlineComponentsRO : ReadOnlyListBase<COnlineComponentsRO, COnlineComponentRO>
    {
        [Fetch]
        private void Fetch([Inject] IOnlineComponentDal compDal, [Inject] IChildDataPortal<COnlineComponentRO> childDataPortal)
        {
            using (LoadListMode)
            {
                List<DOnlineComponentDto> list = null;
                list = compDal.Fetch();
                foreach (var item in list)
                {
                    Add(childDataPortal.FetchChild(item));
                }
            }
        }
    }
}
