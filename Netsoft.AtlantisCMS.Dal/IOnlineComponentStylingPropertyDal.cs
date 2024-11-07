using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Dal
{
    public interface IOnlineComponentStylingPropertyDal
    {
        DOnlineComponentStylingPropertyDto Fetch(int compId, int stylingPropId);
        List<DOnlineComponentStylingPropertyDto> FetchPropertiesForComponent(int compId);
        List<DOnlineComponentStylingPropertyDto> Fetch();
        void Insert (DOnlineComponentStylingPropertyDto dtoData);
        void Update (DOnlineComponentStylingPropertyDto dtoData);
        void Delete (int stylingPropId, int compId);
    }
}
