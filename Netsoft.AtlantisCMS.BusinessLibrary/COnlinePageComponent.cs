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
    public class COnlinePageComponent : BusinessBase<COnlinePageComponent>
    {
        public static readonly PropertyInfo<int> ParentPageIdProperty = RegisterProperty<int>(c => c.ParentPageId);
        public int ParentPageId
        {
            get { return GetProperty(ParentPageIdProperty); }
            set {  SetProperty(ParentPageIdProperty, value); }
        }
        public static readonly PropertyInfo<int> ComponentIdProperty = RegisterProperty<int>(c => c.ComponentId);
        public int ComponentId
        {
            get { return GetProperty(ComponentIdProperty); }
            set { SetProperty(ComponentIdProperty, value); }
        }
        [Create]
        [RunLocal]
        private void Create()
        {
            BusinessRules.CheckRules();
        }

        [FetchChild]
        private void Fetch(DOnlinePageComponentDto compDto, [Inject] IChildDataPortal<COnlineCompStylingProps> childPortal)
        {
            ComponentId = compDto.ComponentId;
        }

        [InsertChild]
        private void InsertChild(COnlinePageEdit parent, [Inject] IOnlinePageComponentDal componentDal, [Inject] IChildDataPortal<COnlineCompStylingProps> childPortal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlinePageComponentDto
                {
                    ComponentId = this.ComponentId
                };
                componentDal.Insert(item);
            }
            FieldManager.UpdateChildren(this);
        }

        [Insert]
        private void Insert([Inject] IOnlinePageComponentDal componentDal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlinePageComponentDto
                {
                    ComponentId = this.ComponentId,
                };
                componentDal.Insert(item);
            }
        }
        [Update]
        private void Update([Inject] IOnlinePageComponentDal componentDal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlinePageComponentDto
                {
                    ComponentId = this.ComponentId
                };
                componentDal.Update(this.ParentPageId, this.ComponentId, item);
            }
            FieldManager.UpdateChildren(this.ComponentId);
        }
        [Delete]
        private void Delete(int ParentPageId, [Inject] IOnlinePageComponentDal pageDal)
        {
            pageDal.Delete(ParentPageId, ComponentId);
        }

        [DeleteSelfChild]
        private void Delete(COnlinePageEdit parentPage, [Inject] IOnlinePageComponentDal pageCompDal)
        {
            pageCompDal.Delete(parentPage.PageId, ComponentId);
        }
    }
}
