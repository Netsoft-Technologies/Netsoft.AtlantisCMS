using Microsoft.EntityFrameworkCore.Storage.Json;
using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.DalEfCore
{
    public class OnlineStringDal : IOnlineStringDal
    {
        private readonly DbContext db;
        public OnlineStringDal(DbContext context) 
        {
            db = context;
        }
        public DOnlineStringDto Fetch(int id)
        {
            var result = (from r in db._OnlineStrings
                          where r.Id == id
                          select new DOnlineStringDto
                          { 
                              Id = r.Id,
                              Title = r.Title,
                              MessageId = r.MessageId,
                              Message = r.Message
                          }).FirstOrDefault();
            return result;
        }
        public List<DOnlineStringDto> Fetch()
        {
            var result = from r in db._OnlineStrings
                         select new DOnlineStringDto
                         {
                             Id = r.Id,
                             Title = r.Title,
                             MessageId = r.MessageId,
                             Message = r.Message
                         };
            return result.ToList();
        }
        public void Insert (DOnlineStringDto dto)
        {
            var newItem = new OnlineStrings_Entity
            { Title = dto.Title,
              MessageId = dto.MessageId,
              Message = dto.Message };
            db._OnlineStrings.Add(newItem);
            db.SaveChanges();
            dto.Id = newItem.Id;
        }
        public void Update (DOnlineStringDto dto)
        {
            var dtoData = (from r in db._OnlineStrings where r.Id == dto.Id select r).FirstOrDefault();
            if (dtoData == null)
            {
                throw new Exception("Id not found");
            }
            dtoData.Title = dto.Title;
            dtoData.MessageId = dto.MessageId;
            dtoData.Message = dto.Message;
            var result = db.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = (from r in db._OnlineStrings where r.Id == id select r).FirstOrDefault();
            if (data != null)
            {
                db._OnlineStrings.Remove(data);
                db.SaveChanges();
            }
        }

    }
}
