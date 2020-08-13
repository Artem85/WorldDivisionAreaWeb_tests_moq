using Common.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldDivisionAreaWeb.Models;

namespace WorldDivisionAreaWeb.Controllers
{
    public class MacroregionsCrudController : Controller
    {
        public IRepository<Macroregion> Repository { get; set; }

        // GET: MacroregionsCrud
        public ActionResult Index()
        {
            //return View();
            return View(Repository.GetAll());
        }

        public ViewResult Create() {
            //throw new NotImplementedException();
            return View(new Macroregion());
        }

        public ActionResult Create(Macroregion model) {
            //throw new NotImplementedException();
            //Repository.Add(model);
            //Repository.Save();
            //TempData["message"] = "Дані регіону збережено";
            //return RedirectToAction("Index");
            return EditingOperation(model, Repository.Add);
        }

        private ActionResult EditingOperation(Macroregion model, Action<Macroregion> action) {
            if (!ModelState.IsValid) {
                return View(model);
            }
            //Repository.Add(model);
            //action(model);
            //Repository.Save();
            try {
                action(model);
                Repository.Save();
            }
            //catch (Exception)
            catch (Exception ex) {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
            //TempData["message"] = "Дані регіону збережено";
            TempData["message"] = string.Format(
                "Дані регіону \"{0}\" збережено", model.Name);
            return RedirectToAction("Index");
        }



    }
}

/*

        public ViewResult Create() {
            //throw new NotImplementedException();
            return View(new Macroregion());
        }

        [HttpPost]
        public ActionResult Create(Macroregion model) {
            //throw new NotImplementedException();
            //Repository.Add(model);
            //Repository.Save();
            //TempData["message"] = "Дані регіону збережено";
            //return RedirectToAction("Index");
            return EditingOperation(model, Repository.Add);
        }


        public ActionResult Edit(Macroregion model) {
            //throw new NotImplementedException();
            //Repository.Update(model);
            //Repository.Save();
            //return RedirectToAction("Index");
            return EditingOperation(model, Repository.Update);
        }

 
 
 
 
 */



