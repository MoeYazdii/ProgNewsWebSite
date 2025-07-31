using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroupRepository : IPageGroupRepository
    {
        private ProgNewsWebSiteContext db;
        public PageGroupRepository(ProgNewsWebSiteContext context)
        {
            this.db = context;
        }



        public bool DeleteGroup(PageGroup pageGroup)
        {
            try
            {
                db.Entry(pageGroup).State = EntityState.Deleted;
                return true;
            }
            catch { return false; }

        }

        public bool DeleteGroupById(int groupId)
        {
            try
            {
                DeleteGroup(GetGroupById(groupId));
                return true;
            }
            catch { return false; }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<PageGroup> GetAllGroups()
        {
            return db.PageGroups;
        }

        public PageGroup GetGroupById(int groupId)
        {
            return db.PageGroups.Find(groupId);
        }

        public bool InsertGroup(PageGroup pageGroup)
        {
            try
            {
                db.PageGroups.Add(pageGroup);
                return true;
            }
            catch { return false; }

        }

        public void Save()
        {
            db.SaveChanges();
        }

        public bool UpdateGroup(PageGroup pageGroup)
        {
            try
            {
                db.Entry(pageGroup).State = EntityState.Modified;
                return true;
            }
            catch { return false; }
        }
    }
}
