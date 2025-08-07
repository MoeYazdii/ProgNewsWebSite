using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
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

        public IEnumerable<NewsPage> LastNewsReturn(int take = 4)
        {
            return db.NewsPage.OrderByDescending(p => p.CreateDate).Take(take);
        }

        public IEnumerable<NewsPage> PagesInSlider()
        {
            return db.NewsPage.Where(p => p.ShowInSlider == true);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<NewsPage> SearchPage(string search)
        {
            return db.NewsPage.Where(p => p.Title.Contains(search) || p.ShortDescription.Contains(search)
            || p.Text.Contains(search) || p.Tags.Contains(search)).Distinct(); //distinct to avoid duplicates
        }

        public IEnumerable<NewsPage> ShowPageByGroupId(int GroupId)
        {
            return db.NewsPage.Where(p => p.GroupID == GroupId);
        }

        public IEnumerable<NewsPage> TopNews(int take = 4)
        {
            return db.NewsPage.OrderByDescending(p => p.Visit).Take(take);
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
