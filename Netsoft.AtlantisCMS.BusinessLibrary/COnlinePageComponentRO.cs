using Csla;
using Csla.Serialization;
using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.BusinessLibrary
{
    [Serializable]
    public class COnlinePageComponentRO : ReadOnlyBase<COnlinePageComponentRO>
    {
        public static readonly PropertyInfo<int> ParentPageIdProperty = RegisterProperty<int>(c => c.ParentPageId);
        public int ParentPageId
        {
            get { return GetProperty(ParentPageIdProperty); }
            private set { LoadProperty(ParentPageIdProperty, value); }
        }
            public static readonly PropertyInfo<int> ComponentIdProperty = RegisterProperty<int>(c => c.CompId);
        public int CompId
        {
            get { return GetProperty(ComponentIdProperty); }
            private set { LoadProperty(ComponentIdProperty, value);  }
        }
        [Fetch]
        private void Fetch(int parentPageId, int componentId, [Inject] IOnlinePageComponentDal compDal, [Inject] IDataPortal<COnlinePageComponentRO> propPortal)
        {
            var item = compDal.Fetch(parentPageId, componentId);
            ParentPageId = item.ParentPageId;
            CompId = item.ComponentId;
        }
        [FetchChild]
        private void FetchChild(DOnlinePageComponentDto item)
        {
            ParentPageId = item.ParentPageId;
            CompId = item.ComponentId;
        }
    }
}
