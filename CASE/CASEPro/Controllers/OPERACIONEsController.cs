using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CASEPro.Models;

namespace CASEPro.Controllers
{   
    public class OPERACIONEsController : Controller
    {
		private readonly IOPERACIONERepository operacioneRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public OPERACIONEsController() : this(new OPERACIONERepository())
        {
        }

        public OPERACIONEsController(IOPERACIONERepository operacioneRepository)
        {
			this.operacioneRepository = operacioneRepository;
        }

        //
        // GET: /OPERACIONEs/

        public ViewResult Index()
        {
            return View(operacioneRepository.AllIncluding(operacione => operacione.ROLES));
        }

        //
        // GET: /OPERACIONEs/Details/5

        public ViewResult Details(decimal id)
        {
            return View(operacioneRepository.Find(id));
        }

        //
        // GET: /OPERACIONEs/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /OPERACIONEs/Create

        [HttpPost]
        public ActionResult Create(OPERACIONE operacione)
        {
            if (ModelState.IsValid) {
                operacioneRepository.InsertOrUpdate(operacione);
                operacioneRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /OPERACIONEs/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(operacioneRepository.Find(id));
        }

        //
        // POST: /OPERACIONEs/Edit/5

        [HttpPost]
        public ActionResult Edit(OPERACIONE operacione)
        {
            if (ModelState.IsValid) {
                operacioneRepository.InsertOrUpdate(operacione);
                operacioneRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /OPERACIONEs/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(operacioneRepository.Find(id));
        }

        //
        // POST: /OPERACIONEs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            operacioneRepository.Delete(id);
            operacioneRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                operacioneRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

