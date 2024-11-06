using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.DalEfCore
{
    public class OnlinePageDal : IOnlinePageDal
    {
        private readonly DbContext db;
        public OnlinePageDal(DbContext dbContext)
        {
            db = dbContext;
        }
        public DOnlinePageDto Fetch(int id)
        {
            var result = (from r in db._OnlinePages
                          where r.PageId == id
                          select new DOnlinePageDto
                          {
                              PageId = r.PageId,
                              PageTitle = r.PageTitle,
                              PageOrder = r.PageOrder
                          }).FirstOrDefault();
            return result;
        }
        public List<DOnlinePageDto> Fetch()
        {
            var result = from r in db._OnlinePages
                         select new DOnlinePageDto
                         {
                             PageId = r.PageId,
                             PageTitle = r.PageTitle,
                             PageOrder = r.PageOrder
                         };
            return result.ToList();
        }
        public void Insert(DOnlinePageDto page)
        {
            var newPage = new OnlinePages_Entity
            {
                PageTitle = page.PageTitle,
                PageOrder = page.PageOrder
            };
            db._OnlinePages.Add(newPage);
            db.SaveChanges();
            page.PageId = newPage.PageId;
        }
        public void Update (DOnlinePageDto page)
        {
            var pageData = (from r in db._OnlinePages
                            where r.PageId == page.PageId
                            select r).FirstOrDefault();
            if (pageData == null)
            {
                throw new Exception("IdNotFound");
            }
            pageData.PageTitle = page.PageTitle;
            pageData.PageOrder = page.PageOrder;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var idData = (from r in db._OnlinePages
                          where r.PageId == id
                          select r).FirstOrDefault();
            if (idData != null)
            {
                db._OnlinePages.Remove(idData);
                db.SaveChanges();
            }
        }
    }
}
