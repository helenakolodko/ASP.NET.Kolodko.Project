using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface;
using Log.Interface;
using Forum.ViewModels;

namespace Forum.Controllers
{
    public class TopicController : Controller
    {
        private readonly IService<SectionEntity> sectionService;
        private readonly IService<UserEntity> userService;
        private readonly IServiceWithRaiting<TopicEntity> topicService;
        private readonly IServiceWithRaiting<CommentEntity> commentService;
        private readonly ILogger logger;

        public TopicController(IService<SectionEntity> sectionService,
                               IService<UserEntity> userService,
                               IServiceWithRaiting<TopicEntity> topicService,
                               IServiceWithRaiting<CommentEntity> commentService,
                               ILogger logger)
        {
            this.sectionService = sectionService;
            this.topicService = topicService;
            this.userService = userService;
            this.commentService = commentService;
            this.logger = logger;
        }

        public ActionResult Index()
        {
            var latestTopics = from topic in topicService.GetAllEntities()
                               select new TopicInfoViewModel
                               {
                                   Name = topic.Name,
                                   DateAdded = topic.DateAdded,
                                   Raiting = topicService.GetRaiting(topic),
                                   //Author = userService.GetEntity(topic.UserId),
                                   //Section = sectionService.GetEntity(topic.SectionId),
                               };
            return View(latestTopics);
        }

        public ActionResult Details(int id)
        {
            TopicEntity topic = topicService.GetEntity(id);
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            var sections = sectionService.GetAllEntities()
                .Select(s => new { Id = s.Id, Name = s.Name });
            ViewBag.Sections = new SelectList(sections, "Id", "Name");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TopicCreateViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TopicEntity topic = new TopicEntity() 
                    { 
                        DateAdded = DateTime.Now,
                        UserId = userService.GetByPredicate(u => u.Email == User.Identity.Name).FirstOrDefault().Id,
                        SectionId = 1,
                        Name = viewModel.Name,
                        Text = viewModel.Text,
                    };
                    topicService.Create(topic);
                    return RedirectToAction("Index");
                }
            }
            catch(Exception e)
            {
                logger.Error(e.Message, e);
                return View("Error");
            }
            return View();
        }

        [Authorize]
        // only for the author admins and topic moderators
        public ActionResult Edit(int id)
        {
            TopicEntity topic = topicService.GetEntity(id);
            if (topic == null)
	        {
		        return View("Error");
	        }
            TopicEditViewModel viewModel = new TopicEditViewModel() { Name = topic.Name, Text = topic.Text };
            return View(viewModel);
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TopicEditViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TopicEntity topic = topicService.GetEntity(id);
                    topic.Name = viewModel.Name;
                    topic.Text = viewModel.Text;
                    topicService.Update(topic);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message, e);
                return View("Error");
            }
            return View();
        }


        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Topic/Delete/5

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [ChildActionOnly]
        public ActionResult GetSections()
        {
            
            return PartialView("");
        }
    }
}
