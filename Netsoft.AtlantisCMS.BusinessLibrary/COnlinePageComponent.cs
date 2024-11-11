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
        public static readonly PropertyInfo<string> ParentPageTitleProperty = RegisterProperty<string>(c => c.ParentPageTitle);
        public string ParentPageTitle
        {
            get { return GetProperty(ParentPageTitleProperty); }
            set { SetProperty(ParentPageTitleProperty, value); }
        }
        public static readonly PropertyInfo<int> ComponentIdProperty = RegisterProperty<int>(c => c.ComponentId);
        public int ComponentId
        {
            get { return GetProperty(ComponentIdProperty); }
            set { SetProperty(ComponentIdProperty, value); }
        }
        public static readonly PropertyInfo<string> ComponentDescriptionProperty = RegisterProperty<string>(c => c.ComponentDesc);
        public string ComponentDesc
        {
            get { return GetProperty(ComponentDescriptionProperty); }
            set { SetProperty (ComponentDescriptionProperty, value); }
        }
        public static readonly PropertyInfo<string> ComponentHTMLClassNameProperty = RegisterProperty<string>(c => c.CompHTMLClassName);
        public string CompHTMLClassName
        {
            get { return GetProperty(ComponentHTMLClassNameProperty); }
            set { SetProperty(ComponentHTMLClassNameProperty, value); }
        }
        public static readonly PropertyInfo<string> ComponentHTMLElementIdProperty = RegisterProperty<string>(c => c.CompHTMLElementId);
        public string CompHTMLElementId
        {
            get { return GetProperty(ComponentHTMLElementIdProperty); }
            set { SetProperty(ComponentHTMLElementIdProperty, value); }
        }
        [Create]
        [RunLocal]
        private void Create()
        {
            BusinessRules.CheckRules();
        }
        [FetchChild]
        private void Fetch(DOnlinePageComponentDto compDto)
        {
            ParentPageId = compDto.ParentPageId;
            ParentPageTitle = compDto.ParentPageTitle;
            ComponentId = compDto.ComponentId;
            ComponentDesc = compDto.ComponentDesc;
            CompHTMLClassName = compDto.ComponentHTMLClassName;
            CompHTMLElementId = compDto.ComponentHTMLElementID;
        }



        [InsertChild]
        private void Insert([Inject] IOnlinePageComponentDal componentDal, int pageid)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlinePageComponentDto
                {
                    ParentPageId = pageid,
                    ComponentId = this.ComponentId,
                };
                componentDal.Insert(item);
            }
        }

        [Insert]
        private void Insert([Inject] IOnlinePageComponentDal componentDal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlinePageComponentDto
                {
                    ParentPageId = this.ParentPageId,
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
                    ParentPageId = this.ParentPageId,
                    ComponentId = this.ComponentId
                };
                componentDal.Update(this.ParentPageId, this.ComponentId, item);
            }
            FieldManager.UpdateChildren(this.ComponentId);
        }
        [Delete]
        private void Delete(int ParentPageId, int ComponentId, [Inject] IOnlinePageComponentDal pageDal)
        {
            pageDal.Delete(ParentPageId, ComponentId);
        }
    }
}
