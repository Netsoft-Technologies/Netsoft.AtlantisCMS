using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Dal
{
    public interface IOnlinePageComponentDal
    {
        DOnlinePageComponentDto Fetch(int pageId, int componentId);
        List<DOnlinePageComponentDto> FetchComponentsForPage(int pageId);
        //List<DOnlinePageComponentDto> FetchPagesForComponent(int componentId);
        void Insert(DOnlinePageComponentDto pageComponentDto);
        void Update(int pageId, int componentId, DOnlinePageComponentDto pageComponentDto);
        void Delete(int pageId, int componentId);
    }
}
