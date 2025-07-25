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
        ProgNewsWebSiteContext db = new ProgNewsWebSiteContext();
        public bool DeletePage(Page page)
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

        public IQueryable<Page> GetAllPage()
        {
            return db.Pages;
        }

        public Page GetPageById(int pageId)
        {
            return db.Pages.Find(pageId);
        }

        public bool InsertPage(Page page)
        {
            try
            {
                db.Pages.Add(page);
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

        public bool UpdatePage(Page page)
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
