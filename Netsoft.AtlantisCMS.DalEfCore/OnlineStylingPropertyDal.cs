using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.DalEfCore
{
    public class OnlineStylingPropertyDal : IOnlineStylingPropertyDal
    {
        private readonly DbContext db;
        public OnlineStylingPropertyDal(DbContext context)
        {
            db = context;
        }
        public DOnlineStylingPropertyDto Fetch(int id)
        {
            var res = (from r in db._OnlineStylingProperties
                       where r.Id == id
                       select new DOnlineStylingPropertyDto
                       {
                           Id = r.Id,
                           Description = r.Description,
                           CSSProp = r.CSSProp,
                       }).FirstOrDefault();
            return res;
        }
        public List<DOnlineStylingPropertyDto> Fetch()
        {
            var res = from r in db._OnlineStylingProperties
                      select new DOnlineStylingPropertyDto
                      {
                          Id = r.Id,
                          Description = r.Description,
                          CSSProp = r.CSSProp,
                      };
            return res.ToList();
        }
        public void Insert(DOnlineStylingPropertyDto dto)
        {
            var newStyleProp = new OnlineStylingProp_Entity
            {
                Description = dto.Description,
                CSSProp = dto.CSSProp
            };
            db._OnlineStylingProperties.Add(newStyleProp);
            db.SaveChanges();
            dto.Id = newStyleProp.Id;
        }
        public void Update(DOnlineStylingPropertyDto dto)
        {
            var editStyleProp = (from r in db._OnlineStylingProperties
                                 where r.Id == dto.Id
                                 select r).FirstOrDefault();
            if (editStyleProp == null)
            {
                throw new Exception();
            }
            editStyleProp.Description = dto.Description;
            editStyleProp.CSSProp = dto.CSSProp;
            var res = db.SaveChanges();
        }
        public void Delete(int id)
        {
            var deleteStyleProp = (from r in db._OnlineStylingProperties
                                   where r.Id == id
                                   select r).FirstOrDefault();
            if(deleteStyleProp != null)
            {
                db._OnlineStylingProperties.Remove(deleteStyleProp);
                db.SaveChanges();
            }
        }
    }
}
