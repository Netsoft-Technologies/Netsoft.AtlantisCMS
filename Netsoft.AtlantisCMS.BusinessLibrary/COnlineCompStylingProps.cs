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
    public class COnlineCompStylingProps : BusinessListBase<COnlineCompStylingProps, COnlineCompStylingProp>
    {
        public void RemoveByParent(int parentID)
        {
            var toRemove = (from r in this
                            where r.ComponentId == parentID
                            select r).ToList();
            foreach (var styleprop in toRemove)
            {
                Remove(styleprop);
            }
        }
        public void Remove(int stylingPropId)
        {
            var item = (from r in this
                        where r.StylingPropertyId == stylingPropId
                        select r).FirstOrDefault();
            if (item != null)
            {
                Remove(item);
            }
        }

        [FetchChild]
        private void Fetch(int parentCompId, [Inject] IOnlineComponentStylingPropertyDal dal, [Inject] IChildDataPortal<COnlineCompStylingProp> childPortal)
        {
            var data = dal.FetchPropertiesForComponent(parentCompId);
            using (LoadListMode)
            {
                foreach (var item in data)
                {
                    Add(childPortal.FetchChild(item));
                }
            }
        }
    }
}
