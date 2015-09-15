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

        //
        // GET: /Topic/Details/5

        public ActionResult Details(int id)
        {
            try
            {
                TopicEntity topic = topicService.GetEntity(id);
            }
            catch(Exception e){
                logger.Error("Topic/Details/id error", e);
                View("Error");
            }
            return View();
        }

        //
        // GET: /Topic/Create

        public ActionResult Create()
        {
            var sections = sectionService.GetAllEntities()
                .Select(s => new SectionHeaderViewModel() { Id = s.Id, Name = s.Name });
            SectionSelectViewModel section = new SectionSelectViewModel(sections);

            TopicCreateViewModel viewModel = new TopicCreateViewModel() { Section = section };
            return View(viewModel);
        }

        //
        // POST: /Topic/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Topic/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Topic/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Topic/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Topic/Delete/5

        [HttpPost]
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
    }
}
