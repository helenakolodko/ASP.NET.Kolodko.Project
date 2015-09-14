using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface;
using Forum.ViewModels;

namespace Forum.Controllers
{
    public class TopicController : Controller
    {
        private readonly IService<SectionEntity> sectionService;
        private readonly IServiceWithRaiting<TopicEntity> topicService;

        public TopicController(IService<SectionEntity> sectionService, IServiceWithRaiting<TopicEntity> topicService)
        {
            this.sectionService = sectionService;
            this.topicService = topicService;
        }

        //
        // GET: /Topic/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Topic/Details/5

        public ActionResult Details(int id)
        {
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
