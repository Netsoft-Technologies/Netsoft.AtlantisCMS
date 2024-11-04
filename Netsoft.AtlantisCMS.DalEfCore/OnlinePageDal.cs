using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Netsoft.AtlantisCMS.DalEfCore.TicketContext;

namespace Netsoft.AtlantisCMS.DalEfCore
{
    public class OnlinePageDal : IOnlinePagesDal
    {
        private readonly TicketContext db;

        public OnlinePageDal(TicketContext context)
        {
            db = context;
        }

        public DOnlinePageDto Fetch(int id) //GET(id)
        {
            var result = (from r in db._OnlinePages
                          where r.Id == id
                          select new DOnlinePageDto
                          {
                              Id = r.Id,
                              Title = r.Title,
                              PageOrder = r.PageOrder,
                          }).FirstOrDefault();
            return result;
        }

        public List<DOnlinePageDto> Fetch()
        {
            var result = from r in db._OnlinePages
                         select new DOnlinePageDto
                         {
                             Id = r.Id,
                             Title = r.Title,
                             PageOrder = r.PageOrder,
                         };
            return result.ToList();
        }

        public void Insert(DOnlinePageDto dto) 
        {
            var newItem = new OnlinePages_Entity
            {
                Title = dto.Title,
                PageOrder = dto.PageOrder,
            };
            db.SaveChanges();
            dto.Id = newItem.Id;
        }

        public void Update (DOnlinePageDto dto)
        {
            var data = (from r in db._OnlinePages
                        where r.Id == dto.Id
                        select r).FirstOrDefault();
            if (data == null)
            {
                throw new Exception("Data Not Found. Check Id");
                data.Title = dto.Title;
                data.PageOrder = dto.PageOrder;
                var count = db.SaveChanges();
            }
        }

        public void Delete (int id)
        {
            var data = (from r in db._OnlinePages
                        where r.Id == id
                        select r).FirstOrDefault();
            if (data != null)
            {
                db._OnlinePages.Remove(data);
                db.SaveChanges();
            }
        }

    }
}
