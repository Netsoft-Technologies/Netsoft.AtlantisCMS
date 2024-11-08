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
    public class COnlineComponentEdit : BusinessBase<COnlineComponentEdit>
    {
        public static readonly PropertyInfo<int> CompIdProperty = RegisterProperty<int>(p => p.CompId);
        public int CompId
        {
            get { return GetProperty(CompIdProperty); }
            set { SetProperty(CompIdProperty, value); }
        }
        public static readonly PropertyInfo<string> CompDescProperty = RegisterProperty<string>(p => p.CompDesc);
        public string CompDesc
        {
            get { return GetProperty(CompDescProperty); }
            set { SetProperty(CompDescProperty, value); }
        }
        public static readonly PropertyInfo<string> CompHTMLClassProperty = RegisterProperty<string>(p => p.CompHTMLClass);
        public string CompHTMLClass
        {
            get { return GetProperty(CompHTMLClassProperty); }
            set { SetProperty(CompHTMLClassProperty, value); }
        }
        public static readonly PropertyInfo<string> CompHTMLElementProperty = RegisterProperty<string>(p => p.CompHTMLElement);
        public string CompHTMLElement
        {
            get { return GetProperty(CompHTMLElementProperty); }
            set { SetProperty(CompHTMLElementProperty, value); }
        }
        public static readonly PropertyInfo<int?> StringContentIdProperty = RegisterProperty<int?>(p => p.StringContentId);
        public int? StringContentId
        {
            get { return GetProperty(StringContentIdProperty); }
            set { SetProperty(StringContentIdProperty, value); }
        }
        public static readonly PropertyInfo<COnlineCompStylingProps> StylingPropsProperty = RegisterProperty<COnlineCompStylingProps>(p => p.StylingProps);
        public COnlineCompStylingProps StylingProps
        {
            get { return GetProperty(StylingPropsProperty); }
            private set {  LoadProperty(StylingPropsProperty, value); }
        }
        [Create]
        [RunLocal]
        private void Create()
        {
            CompDesc = "New Description";
            BusinessRules.CheckRules();
        }
        [Fetch]
        private void Fetch(int compId, [Inject] IOnlineComponentDal compDal, [Inject] IChildDataPortal<COnlineCompStylingProps> childPortal)
        {
            var item = compDal.Fetch(compId);
            using (BypassPropertyChecks)
            {
                CompId = item.Id;
                CompDesc = item.Description;
                CompHTMLClass = item.HTMLClassName;
                CompHTMLElement = item.HTMLClassName;
                StringContentId = item.StringContentId;
                StylingProps = childPortal.FetchChild(compId);
            }
        }
        [Insert]
        private void Insert([Inject] IOnlineComponentDal compDal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlineComponentDto
                {
                    Description = this.CompDesc,
                    HTMLClassName = this.CompHTMLClass,
                    HTMLElementId = this.CompHTMLElement,
                    StringContentId = this.StringContentId
                };
                compDal.Insert(item);
                CompId = item.Id;
            }
            FieldManager.UpdateChildren(this);
        }
        [Update]
        private void Update([Inject] IOnlineComponentDal compDal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlineComponentDto
                {
                    Id = this.CompId,
                    Description = this.CompDesc,
                    HTMLClassName = this.CompHTMLClass,
                    HTMLElementId = this.CompHTMLElement,
                    StringContentId = this.StringContentId
                };
                compDal.Update(item);
            }
            FieldManager.UpdateChildren(this.CompId);
        }
        [Delete]
        private void Delete(int compId, [Inject] IOnlineComponentDal compDal)
        {
            compDal.Delete(compId);
        }
    }
}
