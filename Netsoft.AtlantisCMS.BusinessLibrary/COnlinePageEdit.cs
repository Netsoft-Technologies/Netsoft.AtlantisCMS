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
    public class COnlinePageEdit : BusinessBase<COnlinePageEdit>
    {
        public static readonly PropertyInfo<int> PageIdProperty = RegisterProperty<int>(c => c.PageId);
        public int PageId
        {
            get { return GetProperty(PageIdProperty); }
            set { SetProperty(PageIdProperty, value); }
        }
        public static readonly PropertyInfo<string> PageTitleProperty = RegisterProperty<string>(c => c.PageTitle);
        public string PageTitle
        {
            get { return GetProperty(PageTitleProperty); }
            set { SetProperty(PageTitleProperty, value); }
        }
        public static readonly PropertyInfo<int?> PageOrderProperty = RegisterProperty<int?>(c => c.PageOrder);
        public int? PageOrder
        {

            get { return GetProperty(PageOrderProperty); }
            set { SetProperty(PageOrderProperty, value); }
        }
        public static readonly PropertyInfo<COnlinePageComponents> ComponentsProperty = RegisterProperty<COnlinePageComponents>(nameof(Components));
        public COnlinePageComponents Components
        {
            get { return GetProperty(ComponentsProperty); }
            set { SetProperty(ComponentsProperty, value);}
        }
        [Create]
        [RunLocal]
        private void Create([Inject] IChildDataPortal<COnlinePageComponents> childPortal)
        {
            PageTitle = "New Page Title";
            PageOrder = 0;
            Components=childPortal.CreateChild();
            BusinessRules.CheckRules();
        }
        [Fetch]
        private void Fetch(int pageId, [Inject] IOnlinePageDal pageDal, [Inject] IChildDataPortal<COnlinePageComponents> childPortal)
        {
            var data = pageDal.Fetch(pageId);
            if (data == null)
            {
                return;
            }
            using (BypassPropertyChecks)
            {
                PageId = data.PageId;
                PageTitle = data.PageTitle;
                PageOrder = data.PageOrder;
                Components = childPortal.FetchChild(pageId);
            }
        }
        [FetchChild]
        private void Fetch(DOnlinePageDto pageDto)
        {
            PageId = pageDto.PageId;
            PageTitle = pageDto.PageTitle;
            PageOrder= pageDto.PageOrder;
        }
        [Insert]
        [Transactional]
        private void Insert([Inject]IOnlinePageDal pageDal)
        {
            using (BypassPropertyChecks)
            {
                var pageDto = new DOnlinePageDto
                {
                    PageTitle = this.PageTitle,
                    PageOrder = this.PageOrder
                };
                pageDal.Insert(pageDto);
                this.PageId = pageDto.PageId;
            }
            FieldManager.UpdateChildren(this);
        }
        [Update]
        private void Update([Inject]IOnlinePageDal pageDal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlinePageDto
                {
                    PageId = this.PageId,
                    PageTitle = this.PageTitle,
                    PageOrder = this.PageOrder
                };
                pageDal.Update(item);
            }
            FieldManager.UpdateChildren(this.PageId);
        }
        [Delete]
        private void Delete(int id, [Inject] IOnlinePageDal pageDal)
        {
            pageDal.Delete(id);
        }
    }
}
