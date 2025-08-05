using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageRepository:IDisposable
    {
        IQueryable<NewsPage> GetAllPage();
        NewsPage GetPageById(int pageId);
        bool InsertPage(NewsPage page);
        bool DeletePage(NewsPage page);
        bool DeletePageById(int pageId);
        bool UpdatePage(NewsPage page);
        void Save();

        IEnumerable<NewsPage> TopNews(int take = 4);
        IEnumerable<NewsPage> PagesInSlider();
        IEnumerable<NewsPage> LastNewsReturn(int take = 4);
        IEnumerable<NewsPage> ShowPageByGroupId(int GroupId);

    }
}
