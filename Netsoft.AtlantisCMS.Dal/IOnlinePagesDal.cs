using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Dal
{
    public interface IOnlinePagesDal
    {
        DOnlinePageDto Fetch(int id);
        List<DOnlinePageDto> Fetch();

        void Insert (DOnlinePageDto data);
        void Update (DOnlinePageDto data);
        void Delete (int id);
    }
}
