using Csla;
using Netsoft.AtlantisCMS.Dal;
using Microsoft.Extensions.DependencyInjection;
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
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);

        public int Id
        {
            get { return GetProperty(IdProperty); }
            private set { LoadProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<string> TitleProperty = RegisterProperty<string>(c => c.Title);
        public string Title
        {
            get { return GetProperty(TitleProperty); }
            private set { LoadProperty(TitleProperty, value); }
        }
        public static readonly PropertyInfo<int?> PageOrderProperty = RegisterProperty<int?>(c => c.PageOrder);
        public int? PageOrder
        {
            get { return GetProperty(PageOrderProperty); }
            private set { LoadProperty(PageOrderProperty, value); }
        }
        [Fetch]
        private void Fetch(int id, [Inject] IOnlinePagesDal dal, [Inject] IDataPortal<COnlinePageRO> propertyportal)
        {
            var item = dal.Fetch(id);
            Id = item.Id;
            Title = item.Title;
            PageOrder = item.PageOrder;

        }

        [FetchChild]
        private void FetchChild(DOnlinePageDto item)
        {
            Id = item.Id;
            Title = item.Title;
            PageOrder = item.PageOrder;

        }
    }
}
