using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Dal
{
    public interface IOnlinePageComponentDal
    {
        DOnlinePageComponentDto Fetch(int pageid, int componentid);
        List<DOnlinePageComponentDto> FetchComponentsForPage(int pageid);
        List<DOnlinePageComponentDto> FetchPagesForComponent(int componentid);

        void Insert(DOnlinePageComponentDto pageData);
        void Update(int pageid, int componentid, DOnlinePageComponentDto pageData);
        void Delete(int pageid, int componentid);
    }
}
