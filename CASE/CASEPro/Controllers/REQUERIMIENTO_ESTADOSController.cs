using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CASEPro.Models;

namespace CASEPro.Controllers
{   
    public class REQUERIMIENTO_ESTADOSController : Controller
    {
		private readonly IREQUERIMIENTO_ESTADOSRepository requerimiento_estadosRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public REQUERIMIENTO_ESTADOSController() : this(new REQUERIMIENTO_ESTADOSRepository())
        {
        }

        public REQUERIMIENTO_ESTADOSController(IREQUERIMIENTO_ESTADOSRepository requerimiento_estadosRepository)
        {
			this.requerimiento_estadosRepository = requerimiento_estadosRepository;
        }

        //
        // GET: /REQUERIMIENTO_ESTADOS/

        public ViewResult Index()
        {
            return View(requerimiento_estadosRepository.AllIncluding(requerimiento_estados => requerimiento_estados.REQUERIMIENTOS));
        }

        //
        // GET: /REQUERIMIENTO_ESTADOS/Details/5

        public ViewResult Details(decimal id)
        {
            return View(requerimiento_estadosRepository.Find(id));
        }

        //
        // GET: /REQUERIMIENTO_ESTADOS/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /REQUERIMIENTO_ESTADOS/Create

        [HttpPost]
        public ActionResult Create(REQUERIMIENTO_ESTADOS requerimiento_estados)
        {
            if (ModelState.IsValid) {
                requerimiento_estadosRepository.InsertOrUpdate(requerimiento_estados);
                requerimiento_estadosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /REQUERIMIENTO_ESTADOS/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(requerimiento_estadosRepository.Find(id));
        }

        //
        // POST: /REQUERIMIENTO_ESTADOS/Edit/5

        [HttpPost]
        public ActionResult Edit(REQUERIMIENTO_ESTADOS requerimiento_estados)
        {
            if (ModelState.IsValid) {
                requerimiento_estadosRepository.InsertOrUpdate(requerimiento_estados);
                requerimiento_estadosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /REQUERIMIENTO_ESTADOS/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(requerimiento_estadosRepository.Find(id));
        }

        //
        // POST: /REQUERIMIENTO_ESTADOS/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            requerimiento_estadosRepository.Delete(id);
            requerimiento_estadosRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                requerimiento_estadosRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

