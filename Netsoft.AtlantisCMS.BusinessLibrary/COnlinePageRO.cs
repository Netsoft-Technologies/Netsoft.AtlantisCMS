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
    public class COnlinePageRO : ReadOnlyBase<COnlinePageRO>
    {
        public static readonly PropertyInfo<int> PageIdProperty = RegisterProperty<int>(c => c.PageId);
        public int PageId
        {
            get { return GetProperty(PageIdProperty); }
            private set { LoadProperty(PageIdProperty, value);  }
        }
        public static readonly PropertyInfo<string> PageTitleProperty = RegisterProperty<string>(c => c.PageTitle);
        public string PageTitle
        {
            get { return GetProperty(PageTitleProperty); }
            private set { LoadProperty(PageTitleProperty, value); }
        }
        public static readonly PropertyInfo<int?> PageOrderProperty = RegisterProperty<int?>(c => c.PageOrder);
        public int? PageOrder
        {
            get { return GetProperty(PageOrderProperty); }
            private set { LoadProperty(PageOrderProperty, value); }
        }
        [Fetch]
        private void Fetch(int id, [Inject]IOnlinePageDal pageDal, [Inject]IDataPortal portal)
        {
            var item = pageDal.Fetch(id);
            PageId = item.PageId;
            PageTitle = item.PageTitle;
            PageOrder = item.PageOrder;
        }
        [FetchChild]
        private void FetchChild(DOnlinePageDto itemDto)
        {
            PageId = itemDto.PageId;
            PageTitle = itemDto.PageTitle;
            PageOrder = itemDto.PageOrder;
        }
    }
}
