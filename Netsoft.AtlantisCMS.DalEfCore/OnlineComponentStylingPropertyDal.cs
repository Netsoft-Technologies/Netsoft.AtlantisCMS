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
        public DOnlineComponentStylingPropertyDto Fetch(int compId, int StylingPropertyId)
        {
            var getSingleResult = (from r in db._OnlineComponent_StylingProperties
                                   where r.ComponentId == compId && r.StylingPropertyId == StylingPropertyId
                                   select new DOnlineComponentStylingPropertyDto
                                   {
                                       StylingPropertyId = r.StylingPropertyId,
                                       ComponentId = r.ComponentId,
                                       Value = r.Value,
                                       //CSSVariable = r.CSSVariable
                                   }).FirstOrDefault();
            return getSingleResult;
        }
        public List<DOnlineComponentStylingPropertyDto> FetchPropertiesForComponent(int compId)
        {
            var getMultiStyleResult = from r in db._OnlineComponent_StylingProperties
                                      where r.ComponentId == compId
                                      select new DOnlineComponentStylingPropertyDto
                                      {
                                          StylingPropertyId = r.StylingPropertyId,
                                          ComponentId = r.ComponentId,
                                          Value = r.Value,
                                          //CSSVariable = "placeholder"
                                      };
            return getMultiStyleResult.ToList();
        }
        public List<DOnlineComponentStylingPropertyDto> Fetch()
        {
            var getAllStyleResult = from r in db._OnlineComponent_StylingProperties
                                    select new DOnlineComponentStylingPropertyDto
                                    {
                                        StylingPropertyId = r.StylingPropertyId,
                                        ComponentId = r.ComponentId,
                                        Value = r.Value,
                                        //CSSVariable = r.CSSVariable
                                    };
            return getAllStyleResult.ToList();
        }
        public void Insert(DOnlineComponentStylingPropertyDto dto)
        {
            var newStyleProp = new OnlineCompStylingProp_Entity
            {
                StylingPropertyId = dto.StylingPropertyId,
                ComponentId = dto.ComponentId,
                Value = dto.Value,
                //CSSVariable = dto.CSSVariable
            };
            db._OnlineComponent_StylingProperties.Add(newStyleProp);
            db.SaveChanges();
            dto.StylingPropertyId = newStyleProp.StylingPropertyId;
            dto.ComponentId = newStyleProp.ComponentId;
        }
        public void Update(int compId, int styleId, DOnlineComponentStylingPropertyDto dto)
        {
            var editStyleProp = (from r in db._OnlineComponent_StylingProperties
                                 where r.ComponentId == compId && r.StylingPropertyId == styleId
                                 select r).FirstOrDefault();
            if (editStyleProp == null)
            {
                throw new Exception();
            }
            editStyleProp.ComponentId = dto.ComponentId;
            editStyleProp.StylingPropertyId = dto.StylingPropertyId;
            editStyleProp.Value = dto.Value;
            //editStyleProp.CSSVariable = dto.CSSVariable;
            var saveEdits = db.SaveChanges();
        }
        public void Delete (int compId, int styleId)
        {
            var deleteStyleProp = (from r in db._OnlineComponent_StylingProperties
                                   where r.StylingPropertyId == styleId
                                   select r).FirstOrDefault();
            if (deleteStyleProp != null)
            {
                db._OnlineComponent_StylingProperties.Remove(deleteStyleProp);
                db.SaveChanges();
            }
        }
    }
}
