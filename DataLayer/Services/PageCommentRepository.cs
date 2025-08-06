using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageCommentRepository : IPageCommentRepotistory
    {
        private ProgNewsWebSiteContext db;
        public PageCommentRepository(ProgNewsWebSiteContext context)
        {
            this.db = context;
        }
        public bool AddComment(PageComment comment)
        {
            try
            {
                db.PageComments.Add(comment);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public IEnumerable<PageComment> GetCommentsByNewsId(int id)
        {
            return db.PageComments.Where(c => c.PageID == id);
        }
    }
}
