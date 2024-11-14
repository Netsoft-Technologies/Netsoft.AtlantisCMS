using Csla;
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
    public class COnlineComponentRO : ReadOnlyBase<COnlineComponentRO>
    {
        public static readonly PropertyInfo<int> CompIdProperty = RegisterProperty<int>(p => p.ComponentId);
        public int ComponentId
        {
            get { return GetProperty(CompIdProperty); }
            private set { LoadProperty(CompIdProperty, value); }
        }
        public static readonly PropertyInfo<string> CompDescProperty = RegisterProperty<string>(p => p.Description);
        public string Description
        {
            get { return GetProperty(CompDescProperty); }
            private set { LoadProperty(CompDescProperty, value); }
        }
        public static readonly PropertyInfo<string> CompHTMLClassProperty = RegisterProperty<string>(p => p.HTMLClassName);
        public string HTMLClassName
        {
            get { return GetProperty(CompHTMLClassProperty); }
            private set { LoadProperty(CompHTMLClassProperty, value); }
        }
        public static readonly PropertyInfo<string> CompHTMLElementProperty = RegisterProperty<string>(p => p.HTMLElementId);
        public string HTMLElementId
        {
            get { return GetProperty(CompHTMLElementProperty); }
            private set { LoadProperty(CompHTMLElementProperty, value); }
        }
        public static readonly PropertyInfo<int?> StringContentIdProperty = RegisterProperty<int?>(p => p.StringContentId);
        public int? StringContentId
        {
            get { return GetProperty(StringContentIdProperty); }
            private set { LoadProperty(StringContentIdProperty, value); }   
        }
        public static readonly PropertyInfo<int?> StylingGroupIdProperty = RegisterProperty<int?>(p => p.StylingGroupId);
        public int? StylingGroupId
        {
            get { return GetProperty(StylingGroupIdProperty); }
            private set { LoadProperty(StylingGroupIdProperty, value); }
        }
        public static readonly PropertyInfo<COnlineCompStylingProps> StylingPropsProperty = RegisterProperty<COnlineCompStylingProps>(p => p.StylingProps);
        public COnlineCompStylingProps StylingProps
        {
            get { return GetProperty(StylingPropsProperty); }
            private set { LoadProperty(StylingPropsProperty, value); }
        }
        [Fetch]
        private void Fetch(int compId, [Inject] IOnlineComponentDal compDal, [Inject] IDataPortal<COnlineComponentRO> dataPortal)
        {
            var item = compDal.Fetch(compId);
            ComponentId = item.Id;
            Description = item.Description;
            HTMLClassName = item.HTMLClassName;
            HTMLElementId = item.HTMLElementId;
            StringContentId = item.StringContentId;
            StylingGroupId = item.StylingGroupId;
        }
        [FetchChild]
        private void FetchChild(DOnlineComponentDto compDto)
        {
            ComponentId = compDto.Id;
            Description = compDto.Description;
            HTMLClassName = compDto.HTMLClassName;
            HTMLElementId = compDto.HTMLElementId;
            StringContentId = compDto.StringContentId;
            StylingGroupId = compDto.StylingGroupId;
        }
    }
}
