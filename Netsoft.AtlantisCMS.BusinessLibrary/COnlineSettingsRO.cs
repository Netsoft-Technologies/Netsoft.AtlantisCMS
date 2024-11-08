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
    public class COnlineSettingsRO : ReadOnlyListBase<COnlineSettingsRO, COnlineSettingRO>
    {
        [Fetch]
        private void Fetch([Inject] IOnlineSettingDal dal, [Inject]IChildDataPortal<COnlineSettingRO> portal)
        {
            using (LoadListMode)
            {
                List<DOnlineSettingDto> list = null;
                list = dal.Fetch();
                foreach (var item in list)
                {
                    Add(portal.FetchChild(item));
                }
            }
        }
    }
}
