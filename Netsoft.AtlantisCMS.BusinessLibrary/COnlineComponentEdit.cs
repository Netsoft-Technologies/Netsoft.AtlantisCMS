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
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(p => p.Id);
        public int Id
        {
            get { return GetProperty(IdProperty); }
            set { SetProperty(IdProperty, value); }
        }
        public static readonly PropertyInfo<string> CompDescProperty = RegisterProperty<string>(p => p.Description);
        public string Description
        {
            get { return GetProperty(CompDescProperty); }
            set { SetProperty(CompDescProperty, value); }
        }
        public static readonly PropertyInfo<string> CompHTMLClassProperty = RegisterProperty<string>(p => p.HTMLClassName);
        public string HTMLClassName
        {
            get { return GetProperty(CompHTMLClassProperty); }
            set { SetProperty(CompHTMLClassProperty, value); }
        }
        public static readonly PropertyInfo<string> CompHTMLElementProperty = RegisterProperty<string>(p => p.HTMLElementId);
        public string HTMLElementId
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
        public static readonly PropertyInfo<int?> StylingGroupIdProperty = RegisterProperty<int?>(p => p.StylingGroupId);
        public int? StylingGroupId
        {
            get { return GetProperty(StylingGroupIdProperty); }
            set { SetProperty(StylingGroupIdProperty, value); }
        }
        public static readonly PropertyInfo<COnlineCompStylingProps> StylingPropsProperty = RegisterProperty<COnlineCompStylingProps>(p => p.StylingProps);
        public COnlineCompStylingProps StylingProps
        {
            get { return GetProperty(StylingPropsProperty); }
            set { SetProperty(StylingPropsProperty, value); }
        }
        [Create]
        [RunLocal]
        private void Create([Inject] IChildDataPortal<COnlineCompStylingProps> childPortal)
        {
            Description = "New Description";
            StylingProps = childPortal.CreateChild();
            BusinessRules.CheckRules();
        }
        [Fetch]
        private void Fetch(int compId, [Inject] IOnlineComponentDal compDal, [Inject] IChildDataPortal<COnlineCompStylingProps> childPortal)
        {
            var item = compDal.Fetch(compId);
            if (item == null)
            {
                return;
            }
            using (BypassPropertyChecks)
            {
                Id = item.Id;
                Description = item.Description;
                HTMLClassName = item.HTMLClassName;
                HTMLElementId = item.HTMLElementId;
                StringContentId = item.StringContentId;
                StylingGroupId = item.StylingGroupId;
                StylingProps = childPortal.FetchChild(compId);
            }
        }
        [FetchChild]
        private void Fetch(DOnlineComponentDto componentDto)
        {
            Id = componentDto.Id;
            Description = componentDto.Description;
            HTMLClassName = componentDto.HTMLClassName;
            HTMLElementId = componentDto.HTMLClassName;
            StringContentId = componentDto.StringContentId;
            StylingGroupId = componentDto.StylingGroupId;
        }
        [Insert]
        [Transactional]
        private void Insert([Inject] IOnlineComponentDal compDal)
        {
            using (BypassPropertyChecks)
            {
                var componentDto = new DOnlineComponentDto
                {
                    Description = this.Description,
                    HTMLClassName = this.HTMLClassName,
                    HTMLElementId = this.HTMLElementId,
                    StringContentId = this.StringContentId,
                    StylingGroupId = this.StylingGroupId
                };
                compDal.Insert(componentDto);
                this.Id = componentDto.Id;
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
                    Id = this.Id,
                    Description = this.Description,
                    HTMLClassName = this.HTMLClassName,
                    HTMLElementId = this.HTMLElementId,
                    StringContentId = this.StringContentId,
                    StylingGroupId = this.StylingGroupId
                };
                compDal.Update(item);
            }
            FieldManager.UpdateChildren(this.Id);
        }
        [Delete]
        private void Delete(int compId, [Inject] IOnlineComponentDal compDal)
        {
            compDal.Delete(compId);
        }
    }
}
