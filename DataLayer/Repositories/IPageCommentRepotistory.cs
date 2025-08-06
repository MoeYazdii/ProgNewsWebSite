using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageCommentRepotistory
    {
        IEnumerable<PageComment> GetCommentsByNewsId(int id);
        bool AddComment (PageComment comment);
    }
}
