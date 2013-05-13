using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CASEPro.Models;

namespace CASEPro.Controllers
{   
    public class REQUERIMIENTO_TIPOSController : Controller
    {
		private readonly IREQUERIMIENTO_TIPOSRepository requerimiento_tiposRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public REQUERIMIENTO_TIPOSController() : this(new REQUERIMIENTO_TIPOSRepository())
        {
        }

        public REQUERIMIENTO_TIPOSController(IREQUERIMIENTO_TIPOSRepository requerimiento_tiposRepository)
        {
			this.requerimiento_tiposRepository = requerimiento_tiposRepository;
        }

        //
        // GET: /REQUERIMIENTO_TIPOS/

        public ViewResult Index()
        {
            return View(requerimiento_tiposRepository.AllIncluding(requerimiento_tipos => requerimiento_tipos.REQUERIMIENTOS));
        }

        //
        // GET: /REQUERIMIENTO_TIPOS/Details/5

        public ViewResult Details(decimal id)
        {
            return View(requerimiento_tiposRepository.Find(id));
        }

        //
        // GET: /REQUERIMIENTO_TIPOS/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /REQUERIMIENTO_TIPOS/Create

        [HttpPost]
        public ActionResult Create(REQUERIMIENTO_TIPOS requerimiento_tipos)
        {
            if (ModelState.IsValid) {
                requerimiento_tiposRepository.InsertOrUpdate(requerimiento_tipos);
                requerimiento_tiposRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /REQUERIMIENTO_TIPOS/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(requerimiento_tiposRepository.Find(id));
        }

        //
        // POST: /REQUERIMIENTO_TIPOS/Edit/5

        [HttpPost]
        public ActionResult Edit(REQUERIMIENTO_TIPOS requerimiento_tipos)
        {
            if (ModelState.IsValid) {
                requerimiento_tiposRepository.InsertOrUpdate(requerimiento_tipos);
                requerimiento_tiposRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /REQUERIMIENTO_TIPOS/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(requerimiento_tiposRepository.Find(id));
        }

        //
        // POST: /REQUERIMIENTO_TIPOS/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            requerimiento_tiposRepository.Delete(id);
            requerimiento_tiposRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                requerimiento_tiposRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

