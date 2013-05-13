using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CASEPro.Models;

namespace CASEPro.Controllers
{   
    public class REQUERIMIENTO_DETALLESController : Controller
    {
		private readonly IREQUERIMIENTO_DETALLESRepository requerimiento_detallesRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public REQUERIMIENTO_DETALLESController() : this(new REQUERIMIENTO_DETALLESRepository())
        {
        }

        public REQUERIMIENTO_DETALLESController(IREQUERIMIENTO_DETALLESRepository requerimiento_detallesRepository)
        {
			this.requerimiento_detallesRepository = requerimiento_detallesRepository;
        }

        //
        // GET: /REQUERIMIENTO_DETALLES/

        public ViewResult Index()
        {
            return View(requerimiento_detallesRepository.All);
        }

        //
        // GET: /REQUERIMIENTO_DETALLES/Details/5

        public ViewResult Details(decimal id)
        {
            return View(requerimiento_detallesRepository.Find(id));
        }

        //
        // GET: /REQUERIMIENTO_DETALLES/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /REQUERIMIENTO_DETALLES/Create

        [HttpPost]
        public ActionResult Create(REQUERIMIENTO_DETALLES requerimiento_detalles)
        {
            if (ModelState.IsValid) {
                requerimiento_detallesRepository.InsertOrUpdate(requerimiento_detalles);
                requerimiento_detallesRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /REQUERIMIENTO_DETALLES/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(requerimiento_detallesRepository.Find(id));
        }

        //
        // POST: /REQUERIMIENTO_DETALLES/Edit/5

        [HttpPost]
        public ActionResult Edit(REQUERIMIENTO_DETALLES requerimiento_detalles)
        {
            if (ModelState.IsValid) {
                requerimiento_detallesRepository.InsertOrUpdate(requerimiento_detalles);
                requerimiento_detallesRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /REQUERIMIENTO_DETALLES/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(requerimiento_detallesRepository.Find(id));
        }

        //
        // POST: /REQUERIMIENTO_DETALLES/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            requerimiento_detallesRepository.Delete(id);
            requerimiento_detallesRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                requerimiento_detallesRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

