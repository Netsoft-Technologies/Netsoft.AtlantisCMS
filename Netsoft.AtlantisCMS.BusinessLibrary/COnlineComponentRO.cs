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
        public static readonly PropertyInfo<int> CompIdProperty = RegisterProperty<int>(p => p.CompId);
        public int CompId
        {
            get { return GetProperty(CompIdProperty); }
            private set { LoadProperty(CompIdProperty, value); }
        }
        public static readonly PropertyInfo<string> CompDescProperty = RegisterProperty<string>(p => p.CompDesc);
        public string CompDesc
        {
            get { return GetProperty(CompDescProperty); }
            private set { LoadProperty(CompDescProperty, value); }
        }
        public static readonly PropertyInfo<string> CompHTMLClassProperty = RegisterProperty<string>(p => p.CompHTMLClass);
        public string CompHTMLClass
        {
            get { return GetProperty(CompHTMLClassProperty); }
            private set { LoadProperty(CompHTMLClassProperty, value); }
        }
        public static readonly PropertyInfo<string> CompHTMLElementProperty = RegisterProperty<string>(p => p.CompHTMLElement);
        public string CompHTMLElement
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
        [Fetch]
        private void Fetch(int compId, [Inject] IOnlineComponentDal compDal, [Inject] IDataPortal<COnlineComponentRO> dataPortal)
        {
            var item = compDal.Fetch(compId);
            CompId = item.Id;
            CompDesc = item.Description;
            CompHTMLClass = item.HTMLClassName;
            CompHTMLElement = item.HTMLElementId;
            StringContentId = item.StringContentId;
        }
        [FetchChild]
        private void FetchChild(DOnlineComponentDto compDto)
        {
            CompId = compDto.Id;
            CompDesc = compDto.Description;
            CompHTMLClass = compDto.HTMLClassName;
            CompHTMLElement = compDto.HTMLElementId;
            StringContentId = compDto.StringContentId;
        }
    }
}
