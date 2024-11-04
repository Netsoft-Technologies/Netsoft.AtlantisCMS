using Csla;
using Csla.Core;
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

    }
}
