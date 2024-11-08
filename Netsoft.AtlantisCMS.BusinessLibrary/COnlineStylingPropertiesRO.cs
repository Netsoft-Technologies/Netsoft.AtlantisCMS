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
        private void Fetch([Inject] IOnlineStylingPropertyDal stylePropDal, [Inject]IChildDataPortal<COnlineStylingPropertyRO> childPortal)
        {
            using (LoadListMode)
            {
                List<DOnlineStylingPropertyDto> list = null;
                list = stylePropDal.Fetch();
                foreach (var item in list)
                {
                    Add(childPortal.FetchChild(item));
                }
            }
        }
    }
}
