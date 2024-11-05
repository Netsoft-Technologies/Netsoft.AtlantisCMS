using Csla;
using Csla.Core;
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
        public static readonly PropertyInfo<int> PageIdProperty = RegisterProperty<int>(c => c.PageId);
        public int PageId
        {
            get { return GetProperty(PageIdProperty); }
            set { SetProperty(PageIdProperty, value); }
        }

        public static readonly PropertyInfo<int> ComponentIdProperty = RegisterProperty<int>(c => c.ComponentId);
        public int ComponentId
        {
            get { return GetProperty(ComponentIdProperty); }
            set { SetProperty(ComponentIdProperty, value); }
        }

        public static readonly PropertyInfo<string> ComponentDescriptionProperty = RegisterProperty<string>(c => c.ComponentDescription);
        public string ComponentDescription
        {
            get { return GetProperty(ComponentDescriptionProperty); }
            set { SetProperty(ComponentDescriptionProperty, value); }
        }

        public static readonly PropertyInfo<string> ComponentHTMLClassNameProperty = RegisterProperty<string>(c => c.ComponentHTMLClassName);
        public string ComponentHTMLClassName
        {
            get { return GetProperty(ComponentHTMLClassNameProperty); }
            set { SetProperty(ComponentHTMLClassNameProperty, value); }
        }

        public static readonly PropertyInfo<string> ComponentHTMLElementIdProperty = RegisterProperty<string>(c => c.ComponentHTMLElementId);
        public string ComponentHTMLElementId
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
        private void Fetch(DOnlinePageComponentDto component)
        {
            PageId = component.PageId;
            ComponentId = component.ComponentId;
            ComponentDescription = component.ComponentDescription;
            ComponentHTMLClassName = component.ComponentHTMLClassName;
            ComponentHTMLElementId = component.ComponentHTMLElementId;
        }

        private void Insert([Inject] IOnlinePageComponentDal dal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlinePageComponentDto
                {
                    PageId = this.PageId,
                    ComponentId = this.ComponentId
                };
                dal.Insert(item);
            }

            FieldManager.UpdateChildren(this);
        }

        [Update]
        private void Update([Inject] IOnlinePageComponentDal dal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlinePageComponentDto
                {
                    PageId = this.PageId,
                    ComponentId = this.ComponentId
                };

                dal.Update(this.PageId, this.ComponentId, item);
            }
            FieldManager.UpdateChildren(this.ComponentId);
        }
        [Delete]
        private void Delete (int PageId, int ComponentId, [Inject] IOnlinePageComponentDal dal)
        {
            dal.Delete(PageId, ComponentId);
        }
    }
}
