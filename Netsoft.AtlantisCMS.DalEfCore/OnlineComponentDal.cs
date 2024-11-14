using Microsoft.EntityFrameworkCore.Diagnostics;
using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.DalEfCore
{
    public class OnlineComponentDal : IOnlineComponentDal
    {
        private readonly DbContext db;
        public OnlineComponentDal (DbContext dbContext)
        {
            db = dbContext;
        }
        public DOnlineComponentDto Fetch(int id)
        {
            var getSingleResult = (from r in db._OnlineComponents
                                   where r.Id == id
                              select new DOnlineComponentDto
                              {
                                  Id = r.Id,
                                  Description = r.Description,
                                  HTMLClassName = r.HTMLClassName,
                                  HTMLElementId = r.HTMLElementId,
                                  StringContentId = r.StringContentId,
                                  StylingGroupId = r.StylingGroupId
                              }).FirstOrDefault();
            return getSingleResult ?? new DOnlineComponentDto();
        }
        public List<DOnlineComponentDto> Fetch()
        {
            var getAllResults = from r in db._OnlineComponents
                                select new DOnlineComponentDto
                                {
                                    Id = r.Id,
                                    Description = r.Description,
                                    HTMLClassName = r.HTMLClassName,
                                    HTMLElementId = r.HTMLElementId,
                                    StringContentId = r.StringContentId,
                                    StylingGroupId = r.StylingGroupId
                                };
            return getAllResults.ToList();
        }
        public void Insert(DOnlineComponentDto dto)
        {
            var addComp = new OnlineComp_Entity
            {
                Description = dto.Description,
                HTMLClassName = dto.HTMLClassName,
                HTMLElementId = dto.HTMLElementId,
                StringContentId = dto.StringContentId,
                StylingGroupId = dto.StylingGroupId
            };
            db._OnlineComponents.Add(addComp);
            db.SaveChanges();
            dto.Id = addComp.Id;
        }
        public void Update(DOnlineComponentDto dto)
        {
            var updateComp = (from r in db._OnlineComponents
                              where r.Id == dto.Id
                              select r).FirstOrDefault();
            if (updateComp == null)
            {
                throw new Exception();
            }
            updateComp.Description = dto.Description;
            updateComp.HTMLClassName = dto.HTMLClassName;
            updateComp.HTMLElementId = dto.HTMLElementId;
            updateComp.StringContentId = dto.StringContentId;
            updateComp.StylingGroupId = dto.StylingGroupId;
            var count = db.SaveChanges();
        }
        public void Delete(int id)
        {
            var deleteComp = (from r in db._OnlineComponents
                              where r.Id == id
                              select r).FirstOrDefault();
            if (deleteComp != null)
            {
                db._OnlineComponents.Remove(deleteComp);
                db.SaveChanges();
            }
        }
    }
}
