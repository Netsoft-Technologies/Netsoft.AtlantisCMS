﻿using Csla;
using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.BusinessLibrary
{
    [Serializable]
    public class COnlineCompStylingPropsRO : ReadOnlyListBase<COnlineCompStylingPropsRO, COnlineCompStylingPropRO>
    {
        [Fetch]
        private void Fetch([Inject] IOnlineComponentStylingPropertyDal dal, [Inject] IChildDataPortal<COnlineCompStylingPropRO> childPortal)
        {
            using (LoadListMode)
            {
                List<DOnlineComponentStylingPropertyDto> list = null;
                list = dal.Fetch();
                foreach (var item in list)
                {
                    Add(childPortal.FetchChild(item));
                }
            }
        }
    }
}
