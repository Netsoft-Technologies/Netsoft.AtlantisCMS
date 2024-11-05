using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.DalEfCore
{
    public class TestingTableDal : ITestingTableDal
    {
        private readonly TicketContext db;
        public TestingTableDal (TicketContext context)
        {
            db = context;
        }
        public DTestingTableDto Fetch(int id)
        {
            var result = (from r in db._TestingTable
                          where r.TestId == id
                          select new DTestingTableDto
                          {
                              TestId = r.TestId,
                              TestTitle = r.TestTitle,
                              TestContent = r.TestContent,
                              TestOrder = r.TestOrder,
                              TestTimeCreated = r.TestTimeCreated,
                          }).FirstOrDefault();
            return result;
        }
        public List<DTestingTableDto> Fetch()
        {
            var result = from r in db._TestingTable
                         select new DTestingTableDto
                         {
                             TestId = r.TestId,
                             TestTitle = r.TestTitle,
                             TestContent = r.TestContent,
                             TestOrder = r.TestOrder,
                             TestTimeCreated = r.TestTimeCreated,
                         };
            return result.ToList();
        }
        public void Insert (DTestingTableDto dto)
        {
            var newTestEntry = new TestingTable_Entity
            {
                TestTitle = dto.TestTitle,
                TestContent = dto.TestContent,
                TestOrder = dto.TestOrder,
                TestTimeCreated = DateTime.Now
            };
            db._TestingTable.Add(newTestEntry);
            db.SaveChanges();
            dto.TestId = newTestEntry.TestId;
        }
        public void Update (DTestingTableDto dto)
        {
            var dtoData = (from r in db._TestingTable
                           where r.TestId == dto.TestId
                           select r).FirstOrDefault();
            if (dtoData == null)
            {
                throw new Exception("TestId not found");
            }
            dtoData.TestId = dto.TestId;
            dtoData.TestTitle = dto.TestTitle;
            dtoData.TestContent = dto.TestContent;
            dtoData.TestOrder = dto.TestOrder;
            dtoData.TestTimeCreated = dto.TestTimeCreated;
            var result = db.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = (from r in db._TestingTable
                        where r.TestId == id
                        select r).FirstOrDefault();
            if (data != null )
            {
                db._TestingTable.Remove(data);
                db.SaveChanges();
            }
        }
    }
}
