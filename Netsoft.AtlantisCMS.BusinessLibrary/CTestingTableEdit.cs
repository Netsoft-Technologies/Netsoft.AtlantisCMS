using Csla;
using Csla.Core;
using Csla.Serialization;
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
    public class CTestingTableEdit : BusinessBase <CTestingTableEdit>
    {
        public static readonly PropertyInfo<int> TestIdProperty = RegisterProperty<int>(c => c.TestId);
        public int TestId
        {
            get { return GetProperty(TestIdProperty); }
            set { SetProperty(TestIdProperty, value); }
        }
        public static readonly PropertyInfo<string> TestTitleProperty = RegisterProperty<string>(c => c.TestTitle);
        public string TestTitle
        {
            get { return GetProperty(TestTitleProperty); }
            set { SetProperty(TestTitleProperty, value); }
        }
        public static readonly PropertyInfo<string> TestContentProperty = RegisterProperty<string>(c => c.TestContent);
        public string TestContent
        {
            get { return GetProperty(TestContentProperty); }
            set { SetProperty(TestContentProperty, value); }
        }
        public static readonly PropertyInfo<int?> TestOrderProperty = RegisterProperty<int?>(c => c.TestOrder);
        public int? TestOrder
        {
            get { return GetProperty(TestOrderProperty); }
            set { SetProperty(TestOrderProperty, value); }
        }
        public static readonly PropertyInfo<DateTime?> TestDateProperty = RegisterProperty<DateTime?>(c => c.TestDate);
        public DateTime? TestDate
        {
            get { return GetProperty(TestDateProperty); }
            set { SetProperty(TestDateProperty, value); }
        }
        [Create]
        [RunLocal]
        private void Create()
        {
            TestContent = "New Test Content";
            BusinessRules.CheckRules();
        }
        [Fetch]
        private void Fetch(int id, [Inject] ITestingTableDal testingTableDal)
        {
            var data = testingTableDal.Fetch(id);
            using (BypassPropertyChecks)
            {
                TestId = data.TestId;
                TestTitle = data.TestTitle;
                TestContent = data.TestContent;
                TestOrder = data.TestOrder;
                TestDate = data.TestTimeCreated;
            }
        }
        [FetchChild]
        private void Fetch(DTestingTableDto dto)
        {
            TestId = dto.TestId;
            TestTitle = dto.TestTitle;
            TestContent = dto.TestContent;
            TestOrder = dto.TestOrder;
            TestDate = dto.TestTimeCreated;
        }
        [Insert]
        private void Insert([Inject]ITestingTableDal dal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DTestingTableDto
                {
                    TestId = this.TestId,
                    TestTitle = this.TestTitle,
                    TestContent = this.TestContent,
                    TestOrder = this.TestOrder,
                    TestTimeCreated = DateTime.Now,
                };
                dal.Insert(item);
                TestId = item.TestId;
            }
            FieldManager.UpdateChildren(this);
        }
        [Update]
        private void Update([Inject]ITestingTableDal dal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DTestingTableDto
                {
                    TestId = this.TestId,
                    TestTitle = this.TestTitle,
                    TestContent = this.TestContent,
                    TestOrder = this.TestOrder,
                    TestTimeCreated = this.TestDate,
                };
                dal.Update(item);
            }
            FieldManager.UpdateChildren(this.TestId);
        }
        [Delete]
        private void Delete(int id, [Inject]ITestingTableDal dal)
        {
            dal.Delete(id);
        }
    }
}
