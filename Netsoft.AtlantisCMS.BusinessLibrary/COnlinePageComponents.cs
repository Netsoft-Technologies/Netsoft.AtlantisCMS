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
    public class COnlinePageComponents : BusinessListBase<COnlinePageComponents, COnlinePageComponent>
    {
        public void RemoveByParent(int parentID)
        {
            var toRemove = (from r in this
                            where r.ParentPageId == parentID
                            select r).ToList();
            foreach (var pageComp in toRemove)
            {
                Remove(pageComp);
            }
        }
        public void Remove(int componentId)
        {
            var item = (from r in this
                        where r.ComponentId == componentId
                        select r).FirstOrDefault();
            if (item != null)
            {
                Remove(item);
            }
        }
        [FetchChild]
        private void Fetch(int parentPageId, [Inject] IOnlinePageComponentDal compDal, [Inject] IChildDataPortal<COnlinePageComponent> portal)
        {
            var data = compDal.FetchComponentsForPage(parentPageId);
            using (LoadListMode)
            {
                foreach (var item in data)
                {
                    Add(portal.FetchChild(item));
                }
            }
        }
    }
}
