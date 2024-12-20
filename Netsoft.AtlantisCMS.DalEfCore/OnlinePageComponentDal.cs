﻿using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.DalEfCore
{
    public class OnlinePageComponentDal : IOnlinePageComponentDal
    {
        private readonly DbContext _dbContext;
        public OnlinePageComponentDal(DbContext context)
        {
                _dbContext = context;
        }
        public DOnlinePageComponentDto Fetch(int pageId, int compId)
        {
            var result = (from r in _dbContext._OnlinePage_Components
                          where r.PageId == pageId && r.ComponentId == compId
                          select new DOnlinePageComponentDto
                          {

                              ComponentId = r.ComponentId,
                              ParentPageId = r.PageId
                          }).FirstOrDefault();
            return result;
        }
        public List<DOnlinePageComponentDto> FetchPagesForComponent(int compId)
        {

            //PLACEHOLDER -- May be needed in the future
            //-------------------------------------------------------------------//
            //var result = from page in _dbContext._OnlinePages
            //             join pageComponent in _dbContext._OnlinePage_Components
            //                on page.PageId equals pageComponent.PageId
            //             join component in _dbContext._OnlineComponents
            //                on pageComponent.ComponentId equals component.Id
            //             where pageComponent.ComponentId == compId
            //             select new DOnlinePageComponentDto
            //             {
            //                 ParentPageId = pageComponent.PageId
            //                 ComponentId = component.Id
            //             };
            //-------------------------------------------------------------------//

            var result = from comp in _dbContext._OnlinePage_Components
                         where comp.ComponentId == compId
                         select new DOnlinePageComponentDto
                         {
                             ComponentId = comp.ComponentId,
                             ParentPageId = comp.PageId
                         };
            return result.ToList();
        }
        public List<DOnlinePageComponentDto> FetchComponentsForPage(int pageId)
        {

            //PLACEHOLDER -- May be needed in the future
            //-------------------------------------------------------------------//
            //var result = from page in _dbContext._OnlinePages
            //             join pageComponent in _dbContext._OnlinePage_Components
            //                on page.PageId equals pageComponent.ParentPageId
            //             join component in _dbContext._OnlineComponents
            //                on pageComponent.ComponentId equals component.Id
            //             where pageComponent.ParentPageId == pageId
            //             select new DOnlinePageComponentDto
            //             {
            //                 ParentPageId = pageId,
            //                 //ParentPageTitle = pageComponent.ParentPageTitle,
            //                 ComponentId = component.Id,
            //                 ComponentDesc = pageComponent.ComponentDescription,
            //                 //ComponentHTMLClassName = pageComponent.ComponentHTMLClassName,
            //                 //ComponentHTMLElementID = pageComponent.ComponentHTMLElementID
            //             };
            //-------------------------------------------------------------------//

            var result = from comp in _dbContext._OnlinePage_Components
                         where comp.PageId == pageId
                         select new DOnlinePageComponentDto
                         {
                             ComponentId = comp.ComponentId,
                             ParentPageId = comp.PageId

                         };
            return result.ToList();
        }
        public void Insert(DOnlinePageComponentDto pageComponentDto)
        {
            var newComp = new OnlinePageComponents_Entity
            {
                PageId = pageComponentDto.ParentPageId,
                ComponentId = pageComponentDto.ComponentId
            };
            _dbContext._OnlinePage_Components.Add(newComp);
            _dbContext.SaveChanges();
            pageComponentDto.ParentPageId = newComp.PageId;
            pageComponentDto.ComponentId = newComp.ComponentId;
        }
        public void Update(int pageId, int compId, DOnlinePageComponentDto dto)
        {
            var data = (from r in _dbContext._OnlinePage_Components
                        where r.PageId == pageId && r.ComponentId == compId
                        select r).FirstOrDefault();
            if (data == null)
            {
                throw new Exception();
            }
            data.PageId = dto.ParentPageId;
            data.ComponentId = dto.ComponentId;
            var count = _dbContext.SaveChanges();
        }
        public void Delete(int pageId, int compId)
        {
            var data = (from r in _dbContext._OnlinePage_Components
                        where r.PageId == pageId && r.ComponentId == compId
                        select r).FirstOrDefault();
            if (data != null)
            {
                _dbContext._OnlinePage_Components.Remove(data);
                _dbContext.SaveChanges();
            }
        }
    }
}
