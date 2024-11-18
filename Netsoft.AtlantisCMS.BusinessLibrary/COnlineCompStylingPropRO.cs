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
    public class COnlineCompStylingPropRO : ReadOnlyBase<COnlineCompStylingPropRO>
    {
        public static readonly PropertyInfo<int> StylingPropIDProperty = RegisterProperty<int>(c => c.StylingPropertyId);
        public int StylingPropertyId
        {
            get { return GetProperty(StylingPropIDProperty); }
            private set { LoadProperty(StylingPropIDProperty, value); }
        }
        public static readonly PropertyInfo<int> CompIdProperty = RegisterProperty<int>(c => c.ComponentId);
        public int ComponentId
        {
            get { return GetProperty(CompIdProperty); }
            private set { LoadProperty(CompIdProperty, value); }
        }
        public static readonly PropertyInfo<string> StyleValueProp = RegisterProperty<string>(c => c.Value);
        public string Value
        {
            get { return GetProperty(StyleValueProp); }
            private set { LoadProperty(StyleValueProp, value); }
        }
        [Fetch]
        private void Fetch(int compId, int stylingPropId, [Inject] IOnlineComponentStylingPropertyDal dal, [Inject] IDataPortal<COnlineCompStylingPropRO> dataPortal)
        {
            var style = dal.Fetch(compId, stylingPropId);
            StylingPropertyId = style.StylingPropertyId;
            ComponentId = style.ComponentId;
            Value = style.Value;
        }
        [FetchChild]
        private void FetchChild(DOnlineComponentStylingPropertyDto dto)
        {
            StylingPropertyId = dto.StylingPropertyId;
            ComponentId = dto.ComponentId;
            Value = dto.Value;
        }
    }
}
