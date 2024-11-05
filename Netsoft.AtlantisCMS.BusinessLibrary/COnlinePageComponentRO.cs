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
    public class COnlinePageComponentRO : ReadOnlyBase<COnlinePageComponentRO>
    {
        public static readonly PropertyInfo<int> PageIdProperty = RegisterProperty<int>(c => c.PageId);
        public int PageId 
        {
            get { return GetProperty(PageIdProperty); }
            private set { LoadProperty(PageIdProperty, value); }
        }

        public static readonly PropertyInfo<int> ComponentIdProperty = RegisterProperty<int>(c => c.ComponentId);
        public int ComponentId
        {
            get { return GetProperty(ComponentIdProperty);}
            private set { LoadProperty(ComponentIdProperty, value);}
        }
        [Fetch]
        private void Fetch(int pageid, int componentId, [Inject] IOnlinePageComponentDal dal, [Inject] IDataPortal<COnlinePageComponentRO> propertyPortal)
        {
            var item = dal.Fetch(pageid, componentId);
            PageId = item.PageId;
            ComponentId = item.ComponentId;
        }
        [FetchChild]
        private void FetchChild(DOnlinePageComponentDto item)
        {
            PageId = item.PageId;
            ComponentId = item.ComponentId;
        }
    }
}
