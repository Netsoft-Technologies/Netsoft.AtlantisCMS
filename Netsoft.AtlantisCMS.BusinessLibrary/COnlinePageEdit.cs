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
    public class COnlinePageEdit : BusinessBase<COnlinePageEdit>
    {
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
        {
            get { return GetProperty(IdProperty); }
            set { SetProperty(IdProperty, value); }
        }
        public static readonly PropertyInfo<string> TitleProperty = RegisterProperty<string>(c => c.Title);
        public string Title
        {
            get { return GetProperty(TitleProperty); }
            set { SetProperty(TitleProperty, value); }
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
            private set { SetProperty(ComponentsProperty, value); }
        }

        [Create]
        [RunLocal]
        private void Create()
        {
            Title = "New Title";
            PageOrder = 0;
            BusinessRules.CheckRules();
        }
        [Fetch]
        private void Fetch(int id, [Inject] IOnlinePagesDal dal, [Inject] IChildDataPortal<COnlinePageComponents> childportal)
        {
            var data = dal.Fetch(id);
            using (BypassPropertyChecks)
            {
                Id = data.Id;
                Title = data.Title;
                PageOrder = data.PageOrder;
                Components = childportal.FetchChild(id);
            }
        }

        [FetchChild]
        private void Fetch(DOnlinePageDto dto)
        {
            Id = dto.Id;
            Title = dto.Title;
            PageOrder = dto.PageOrder;
        }

        [Insert]
        private void Insert([Inject] IOnlinePagesDal dal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlinePageDto
                {
                    Id = this.Id,
                    Title = this.Title,
                    PageOrder = this.PageOrder
                };

                dal.Insert(item);
                Id = item.Id;
            }

            FieldManager.UpdateChildren(this);
        }

        [Update]
        private void Update([Inject] IOnlinePagesDal dal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlinePageDto
                {
                    Id = this.Id,
                    Title = this.Title,
                    PageOrder = this.PageOrder
                };
                dal.Update(item);
            }
            FieldManager.UpdateChildren(this.Id);
        }

        [Delete]
        private void Delete(int id, [Inject] IOnlinePagesDal dal)
        {
            dal.Delete(id);
        }
    }
}
