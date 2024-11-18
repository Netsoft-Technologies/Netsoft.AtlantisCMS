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
        //public static readonly PropertyInfo<string> ParentPageTitleProperty = RegisterProperty<string>(c => c.ParentPageTitle);
        //public string ParentPageTitle
        //{
        //    get { return GetProperty(ParentPageTitleProperty); }
        //    set { SetProperty(ParentPageTitleProperty, value); }
        //}
        public static readonly PropertyInfo<int> ComponentIdProperty = RegisterProperty<int>(c => c.ComponentId);
        public int ComponentId
        {
            get { return GetProperty(ComponentIdProperty); }
            set { SetProperty(ComponentIdProperty, value); }
        }
        //public static readonly PropertyInfo<string> ComponentDescriptionProperty = RegisterProperty<string>(c => c.ComponentDescription);
        //public string ComponentDescription
        //{
        //    get { return GetProperty(ComponentDescriptionProperty); }
        //    set { SetProperty (ComponentDescriptionProperty, value); }
        //}
        //public static readonly PropertyInfo<string> ComponentHTMLClassNameProperty = RegisterProperty<string>(c => c.ComponentHTMLClassName);
        //public string ComponentHTMLClassName
        //{
        //    get { return GetProperty(ComponentHTMLClassNameProperty); }
        //    set { SetProperty(ComponentHTMLClassNameProperty, value); }
        //}
        //public static readonly PropertyInfo<string> ComponentHTMLElementIdProperty = RegisterProperty<string>(c => c.ComponentHTMLElementId);
        //public string ComponentHTMLElementId
        //{
        //    get { return GetProperty(ComponentHTMLElementIdProperty); }
        //    set { SetProperty(ComponentHTMLElementIdProperty, value); }
        //}
        public static readonly PropertyInfo<COnlineCompStylingProps> ComponentStylingProperty = RegisterProperty<COnlineCompStylingProps>(nameof(ComponentStyling));
        public COnlineCompStylingProps  ComponentStyling
        {
            get { return GetProperty(ComponentStylingProperty); }
            set { SetProperty(ComponentStylingProperty, value); } //not good
        }
        [Create] //[CreateChild]
        [RunLocal]
        private void Create() //[Inject] IChildDataPortal<COnlineCompStylingProps> childPortal
        {
            //ComponentStyling = childPortal.CreateChild();
            BusinessRules.CheckRules();
        }

        [FetchChild]
        private void Fetch(DOnlinePageComponentDto compDto, [Inject] IChildDataPortal<COnlineCompStylingProps> childPortal)
        {
            ComponentId = compDto.ComponentId;
            ParentPageId = compDto.ParentPageId;
            ComponentStyling = childPortal.FetchChild(compDto.ParentPageId);
            //ParentPageTitle = compDto.ParentPageTitle;
            //ComponentDescription = compDto.ComponentDesc;
            //ComponentHTMLClassName = compDto.ComponentHTMLClassName;
            //ComponentHTMLElementId = compDto.ComponentHTMLElementID;
        }



        [InsertChild]
        private void InsertChild(COnlinePageEdit parent, [Inject] IOnlinePageComponentDal componentDal, [Inject] IChildDataPortal<COnlineCompStylingProps> childPortal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlinePageComponentDto
                {
                    ParentPageId = parent.PageId,
                    ComponentId = this.ComponentId
                    //StylingProperty = ComponentStyling
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
        private void Delete(int ParentPageId, [Inject] IOnlinePageComponentDal pageDal)
        {
            pageDal.Delete(ParentPageId, ComponentId);
        }

        [DeleteSelfChild]
        private void Delete(COnlinePageEdit parentPage, [Inject] IOnlinePageComponentDal pageCompDal)
        {
            pageCompDal.Delete(ParentPageId, parentPage.PageId);
        }
    }
}
