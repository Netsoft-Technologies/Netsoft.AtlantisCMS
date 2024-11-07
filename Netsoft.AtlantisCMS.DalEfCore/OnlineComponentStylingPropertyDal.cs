using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.DalEfCore
{
    public class OnlineComponentStylingPropertyDal : IOnlineComponentStylingPropertyDal
    {
        public readonly DbContext db;
        public OnlineComponentStylingPropertyDal(DbContext context)
        {
            db = context;
        }
        public DOnlineComponentStylingPropertyDto Fetch(int compId, int stylingPropId)
        {
            var getSingleResult = (from r in db._OnlineCompStylingProp
                                   where r.ParentCompId == compId && r.StylingPropId == stylingPropId
                                   select new DOnlineComponentStylingPropertyDto
                                   {
                                       StylingPropId = r.StylingPropId,
                                       ParentCompId = r.ParentCompId,
                                       StyleValue = r.StyleValue
                                   }).FirstOrDefault();
            return getSingleResult;
        }
        public List<DOnlineComponentStylingPropertyDto> FetchPropertiesForComponent(int compId)
        {
            var getMultiStyleResult = from r in db._OnlineCompStylingProp
                                      where r.ParentCompId == compId
                                      select new DOnlineComponentStylingPropertyDto
                                      {
                                          StylingPropId = r.StylingPropId,
                                          ParentCompId = r.ParentCompId,
                                          StyleValue = r.StyleValue
                                      };
            return getMultiStyleResult.ToList();
        }
        public List<DOnlineComponentStylingPropertyDto> Fetch()
        {
            var getAllStyleResult = from r in db._OnlineCompStylingProp
                                    select new DOnlineComponentStylingPropertyDto
                                    {
                                        StylingPropId = r.StylingPropId,
                                        ParentCompId = r.ParentCompId,
                                        StyleValue = r.StyleValue
                                    };
            return getAllStyleResult.ToList();
        }
        public void Insert(DOnlineComponentStylingPropertyDto dto)
        {
            var newStyleProp = new OnlineCompStylingProp_Entity
            {
                StylingPropId = dto.StylingPropId,
                ParentCompId = dto.ParentCompId,
                StyleValue = dto.StyleValue
            };
            db._OnlineCompStylingProp.Add(newStyleProp);
            db.SaveChanges();
            dto.StylingPropId = newStyleProp.StylingPropId;
        }
        public void Update(DOnlineComponentStylingPropertyDto dto)
        {
            var editStyleProp = (from r in db._OnlineCompStylingProp
                                 where r.ParentCompId == dto.ParentCompId && r.StylingPropId == dto.StylingPropId
                                 select r).FirstOrDefault();
            if (editStyleProp == null)
            {
                throw new Exception();
            }
            editStyleProp.ParentCompId = dto.ParentCompId;
            editStyleProp.StylingPropId = dto.StylingPropId;
            editStyleProp.StyleValue = dto.StyleValue;
            var saveEdits = db.SaveChanges();
        }
        public void Delete (int compId, int stylingPropId)
        {
            var deleteStyleProp = (from r in db._OnlineCompStylingProp
                                   where r.ParentCompId == compId && r.StylingPropId == stylingPropId
                                   select r).FirstOrDefault();
            if (deleteStyleProp != null)
            {
                db._OnlineCompStylingProp.Remove(deleteStyleProp);
                db.SaveChanges();
            }
        }
    }
}
