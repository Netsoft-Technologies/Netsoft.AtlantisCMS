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
        public static readonly PropertyInfo<int> StylingPropIDProperty = RegisterProperty<int>(c => c.StylingPropId);
        public int StylingPropId
        {
            get { return GetProperty(StylingPropIDProperty); }
            private set { LoadProperty(StylingPropIDProperty, value); }
        }
        public static readonly PropertyInfo<int> CompIdProperty = RegisterProperty<int>(c => c.CompId);
        public int CompId
        {
            get { return GetProperty(CompIdProperty); }
            private set { LoadProperty(CompIdProperty, value); }
        }
        public static readonly PropertyInfo<string> StyleValueProp = RegisterProperty<string>(c => c.StyleValue);
        public string StyleValue
        {
            get { return GetProperty(StyleValueProp); }
            private set { LoadProperty(StyleValueProp, value); }
        }
        [Fetch]
        private void Fetch(int compId, int stylingPropId, [Inject] IOnlineComponentStylingPropertyDal dal, [Inject] IDataPortal<COnlineCompStylingPropRO> dataPortal)
        {
            var style = dal.Fetch(compId, stylingPropId);
            StylingPropId = style.StylingPropId;
            CompId = style.ParentCompId;
            StyleValue = style.StyleValue;
        }
        [FetchChild]
        private void FetchChild(DOnlineComponentStylingPropertyDto dto)
        {
            StylingPropId = dto.StylingPropId;
            CompId = dto.ParentCompId;
            StyleValue = dto.StyleValue;
        }
    }
}
