using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Dal
{
    public interface IOnlineStylingPropertyDal
    {
        DOnlineStylingPropertyDto Fetch(int id);
        List<DOnlineStylingPropertyDto> Fetch();
        void Insert(DOnlineStylingPropertyDto dtoData);
        void Update(DOnlineStylingPropertyDto dtoData);
        void Delete(int id);
    }
}
