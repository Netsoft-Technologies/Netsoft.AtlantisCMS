using Csla;
using Csla.Serialization;
using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.BusinessLibrary
{
    [Serializable]
    public class CTestingTableRO : ReadOnlyBase<CTestingTableRO>
    {
        public static readonly PropertyInfo<int> TestIdProperty = RegisterProperty<int>(c => c.TestId);
        public int TestId
        {
            get { return GetProperty(TestIdProperty); }
            private set { LoadProperty(TestIdProperty, value); }
        }
        public static readonly PropertyInfo<string> TestTitleProperty = RegisterProperty<string>(c => c.TestTitle);
        public string TestTitle
        {
            get { return GetProperty(TestTitleProperty); }
            private set { LoadProperty(TestTitleProperty, value); }
        }
        public static readonly PropertyInfo<string> TestContentProperty = RegisterProperty<string>(c => c.TestContent);
        public string TestContent
        {
            get { return GetProperty(TestContentProperty); }
            private set { LoadProperty(TestContentProperty, value); }
        }
        public static readonly PropertyInfo<int?> TestOrderProperty = RegisterProperty<int?>(c => c.TestOrder);
        public int? TestOrder
        {
            get { return GetProperty(TestOrderProperty); }
            private set { LoadProperty(TestOrderProperty, value); }
        }
        public static readonly PropertyInfo<DateTime?> TestDateProperty = RegisterProperty<DateTime?>(c => c.TestDate);
        public DateTime? TestDate
        {
            get { return GetProperty(TestDateProperty); }
            private set { LoadProperty(TestDateProperty, value); }
        }
        [Fetch]
        private void Fetch(int testId, [Inject] ITestingTableDal testingTableDal, [Inject] IDataPortal<CTestingTableRO> testingPortal)
        {
            var item = testingTableDal.Fetch(testId);
            TestId = item.TestId;
            TestTitle = item.TestTitle;
            TestContent = item.TestContent;
            TestOrder = item.TestOrder;
            TestDate = item.TestTimeCreated;
        }
        [FetchChild]
        private void FetchChile(DTestingTableDto dto)
        {
            TestId = dto.TestId;
            TestTitle = dto.TestTitle;
            TestContent = dto.TestContent;
            TestOrder = dto.TestOrder;
            TestDate = dto.TestTimeCreated;
        }
    }
}
