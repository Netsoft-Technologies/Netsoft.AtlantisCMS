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
        private void Fetch([Inject] IOnlineSettingDal settingDal, [Inject]IChildDataPortal<COnlineSettingRO> settingChildPortal)
        {
            using (LoadListMode)
            {
                List<DOnlineSettingDto> list = null;
                list = settingDal.Fetch();
                foreach (var settingDto in list)
                {
                    Add(settingChildPortal.FetchChild(settingDto));
                }
            }
        }
    }
}
