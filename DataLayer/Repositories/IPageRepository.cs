using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageRepository
    {
        IQueryable<Page> GetAllPage();
        Page GetPageById(int pageId);
        bool InsertPage(Page page);
        bool DeletePage(Page page);
        bool DeletePageById(int pageId);
        bool UpdatePage(Page page);
        void Save();

    }
}
