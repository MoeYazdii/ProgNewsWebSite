using DataLayer;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgNewsWebSite.Controllers
{
    public class NewsController : Controller
    {

        ProgNewsWebSiteContext db = new ProgNewsWebSiteContext();
        private IPageGroupRepository pageGroupRepository;
        private IPageRepository pageRepository;
        private IPageCommentRepotistory pageCommentRepotistory;

        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
            pageCommentRepotistory = new PageCommentRepository(db);
        }
        // GET: News
        public ActionResult ShowGroups()
        {
            return PartialView(pageGroupRepository.GetGroupsForView());
        }

        public ActionResult ShowGroupInMenu()
        {
            return PartialView(pageGroupRepository.GetAllGroups());
        }

        public ActionResult TopNews()
        {
            return PartialView(pageRepository.TopNews());
        }
        public ActionResult LastNews()
        {
            return PartialView(pageRepository.LastNewsReturn());
        }
        [Route("Archive")]
        public ActionResult ArchiveNews()
        {
            return View(pageRepository.GetAllPage());
        }
        [Route("Group/{id}/{title}")]
        public ActionResult ShowNewsByGroupId(int id, string title)
        {
            ViewBag.name = title;
            return View(pageRepository.ShowPageByGroupId(id));
        }

        [Route("News/{id}")]
        public ActionResult ShowNews(int id)
        {
            var news = pageRepository.GetPageById(id);
            if (news == null)
            {
                return HttpNotFound();
            }

            news.Visit += 1;
            pageRepository.UpdatePage(news);
            pageRepository.Save();
            return View(news);
        }

        public ActionResult AddComment(int id, string name, string email, string comment)
        {
            PageComment addedComment = new PageComment()
            {
                CreateDate = DateTime.Now,
                PageID = id,
                Name = name,
                Email = email,
                Comment = comment
            };

            pageCommentRepotistory.AddComment(addedComment);
            return null;
        }
    }
}