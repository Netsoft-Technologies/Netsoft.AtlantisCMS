using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Dal
{
    public interface ITestingTableDal
    {
        DTestingTableDto Fetch(int id);
        List<DTestingTableDto> Fetch();
        void Insert(DTestingTableDto dto);
        void Update(DTestingTableDto dto);
        void Delete(int id);
    }
}
