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
    public class COnlineStylingPropertiesRO : ReadOnlyListBase<COnlineStylingPropertiesRO, COnlineStylingPropertyRO>
    {
        [Fetch]
        private void Fetch([Inject] IOnlineStylingPropertyDal stylePropertyDal, [Inject]IChildDataPortal<COnlineStylingPropertyRO> styleChildPortal)
        {
            using (LoadListMode)
            {
                List<DOnlineStylingPropertyDto> list = null;
                list = stylePropertyDal.Fetch();
                foreach (var item in list)
                {
                    Add(styleChildPortal.FetchChild(item));
                }
            }
        }
    }
}
