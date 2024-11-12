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
    public class COnlinePageComponents : BusinessListBase<COnlinePageComponents, COnlinePageComponent>
    {
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
        //[CreateChild]
        //public void AddNewComp(COnlinePageComponent component)
        //{
        //    if (component != null)
        //    {
        //        Add(component);
        //    }
        //}

        //[UpdateChild]
        //public void UpdateComp(COnlinePageComponent component)
        //{
        //    var existingComp = this;
        //}
    }
}
