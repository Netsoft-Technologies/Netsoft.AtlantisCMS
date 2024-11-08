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
            var res = (from r in db._OnlineStylingProp
                       where r.Id == id
                       select new DOnlineStylingPropertyDto
                       {
                           Id = r.Id,
                           Desc = r.Description,
                           CSSProp = r.CSSProperty,
                       }).FirstOrDefault();
            return res;
        }
        public List<DOnlineStylingPropertyDto> Fetch()
        {
            var res = from r in db._OnlineStylingProp
                      select new DOnlineStylingPropertyDto
                      {
                          Id = r.Id,
                          Desc = r.Description,
                          CSSProp = r.CSSProperty,
                      };
            return res.ToList();
        }
        public void Insert(DOnlineStylingPropertyDto dto)
        {
            var newStyleProp = new OnlineStylingProp_Entity
            {
                Description = dto.Desc,
                CSSProperty = dto.CSSProp
            };
            db._OnlineStylingProp.Add(newStyleProp);
            db.SaveChanges();
            dto.Id = newStyleProp.Id;
        }
        public void Update(DOnlineStylingPropertyDto dto)
        {
            var editStyleProp = (from r in db._OnlineStylingProp
                                 where r.Id == dto.Id
                                 select r).FirstOrDefault();
            if (editStyleProp == null)
            {
                throw new Exception();
            }
            editStyleProp.Description = dto.Desc;
            editStyleProp.CSSProperty = dto.CSSProp;
            var res = db.SaveChanges();
        }
        public void Delete(int id)
        {
            var deleteStyleProp = (from r in db._OnlineStylingProp
                                   where r.Id == id
                                   select r).FirstOrDefault();
            if(deleteStyleProp != null)
            {
                db._OnlineStylingProp.Remove(deleteStyleProp);
                db.SaveChanges();
            }
        }
    }
}
