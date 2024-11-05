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
    public class CTestingTablesRO : ReadOnlyListBase<CTestingTablesRO, CTestingTableRO>
    {
        [Fetch]
        private void Fetch([Inject] ITestingTableDal tableDal, [Inject] IChildDataPortal<CTestingTableRO> testPortal)
        {
            using (LoadListMode)
            {
                List<DTestingTableDto> list = null;
                list = tableDal.Fetch();
                foreach (var item in list)
                {
                    Add(testPortal.FetchChild(item));
                }
            }
        }
    }
}
