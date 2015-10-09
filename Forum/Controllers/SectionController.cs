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
    public class SectionController : Controller
    {
        private readonly IService<SectionEntity> sectionService;
        private readonly ILogger logger;

        public SectionController(IService<SectionEntity> sectionService,
                               ILogger logger)
        {
            this.sectionService = sectionService;
            this.logger = logger;
        }

        public ActionResult Index()
        {
            var sections = from section in sectionService.GetAllEntities()
                           select new SectionViewModel
                           {
                               Id = section.Id,
                               Name = section.Name,
                               Description = section.Info
                           };
            return View(sections);
        }

        public ActionResult Details(int id)
        {
            var section = sectionService.GetEntity(id);
            if (section == null)
            {
                return View("Error");
            }
            SectionViewModel model = new SectionViewModel()
            {
                Id = section.Id,
                Name = section.Name,
                Description = section.Info
            };
            return View(model);
        }

        [Authorize(Roles="admin,sectionmoderator")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin,sectionmoderator")]
        public ActionResult Create(SectionUpdateViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SectionEntity section = new SectionEntity()
                    {
                        Name = viewModel.Name,
                        Info = viewModel.Description,
                    };
                    sectionService.Create(section);
                    return RedirectToAction("Index");
                }
            }
            catch (InvalidOperationException e)
            {
                logger.Error(e.Message, e);
                return View("Error");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            var section = sectionService.GetEntity(id);
            if (section == null)
            {
                return View("Error");
            }            
            SectionUpdateViewModel model = new SectionUpdateViewModel()
            {
                Name = section.Name,
                Description = section.Info
            };
            return View(model);
        }

        

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id, SectionUpdateViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SectionEntity section = new SectionEntity()
                    {
                        Id = id,
                        Name = viewModel.Name,
                        Info = viewModel.Description,
                    };
                    sectionService.Update(section);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(viewModel);
            }
        }

        [Authorize(Roles = "admin,sectionmoderator")]
        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "admin,sectionmoderator")]
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
