using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class PageRepository : IPageRepository
    {
        private ProgNewsWebSiteContext db;

        public PageRepository(ProgNewsWebSiteContext context)
        {
            this.db = context;
        }
        public bool DeletePage(NewsPage page)
        {
            try
            {
                db.Entry(page).State = EntityState.Deleted;
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool DeletePageById(int pageId)
        {
            try
            {
                DeletePage(GetPageById(pageId));
                return true;
            }
            catch
            {
                return false;
            }

        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IQueryable<NewsPage> GetAllPage()
        {
            return db.NewsPage;
        }

        public NewsPage GetPageById(int pageId)
        {
            return db.NewsPage.Find(pageId);
        }

        public bool InsertPage(NewsPage page)
        {
            try
            {
                db.NewsPage.Add(page);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public bool UpdatePage(NewsPage page)
        {
            try
            {
                db.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch { return false; }
        }
    }
}
