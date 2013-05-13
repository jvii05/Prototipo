using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CASEPro.Models;

namespace CASEPro.Controllers
{   
    public class PROYECTO_DETALLESController : Controller
    {
		private readonly IPROYECTO_DETALLESRepository proyecto_detallesRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public PROYECTO_DETALLESController() : this(new PROYECTO_DETALLESRepository())
        {
        }

        public PROYECTO_DETALLESController(IPROYECTO_DETALLESRepository proyecto_detallesRepository)
        {
			this.proyecto_detallesRepository = proyecto_detallesRepository;
        }

        //
        // GET: /PROYECTO_DETALLES/

        public ViewResult Index()
        {
            return View(proyecto_detallesRepository.All);
        }

        //
        // GET: /PROYECTO_DETALLES/Details/5

        public ViewResult Details(decimal id)
        {
            return View(proyecto_detallesRepository.Find(id));
        }

        //
        // GET: /PROYECTO_DETALLES/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /PROYECTO_DETALLES/Create

        [HttpPost]
        public ActionResult Create(PROYECTO_DETALLES proyecto_detalles)
        {
            if (ModelState.IsValid) {
                proyecto_detallesRepository.InsertOrUpdate(proyecto_detalles);
                proyecto_detallesRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /PROYECTO_DETALLES/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(proyecto_detallesRepository.Find(id));
        }

        //
        // POST: /PROYECTO_DETALLES/Edit/5

        [HttpPost]
        public ActionResult Edit(PROYECTO_DETALLES proyecto_detalles)
        {
            if (ModelState.IsValid) {
                proyecto_detallesRepository.InsertOrUpdate(proyecto_detalles);
                proyecto_detallesRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /PROYECTO_DETALLES/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(proyecto_detallesRepository.Find(id));
        }

        //
        // POST: /PROYECTO_DETALLES/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            proyecto_detallesRepository.Delete(id);
            proyecto_detallesRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                proyecto_detallesRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

