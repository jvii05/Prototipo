using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CASEPro.Models;

namespace CASEPro.Controllers
{   
    public class DETALLE_TIPOSController : Controller
    {
		private readonly IDETALLE_TIPOSRepository detalle_tiposRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public DETALLE_TIPOSController() : this(new DETALLE_TIPOSRepository())
        {
        }

        public DETALLE_TIPOSController(IDETALLE_TIPOSRepository detalle_tiposRepository)
        {
			this.detalle_tiposRepository = detalle_tiposRepository;
        }

        //
        // GET: /DETALLE_TIPOS/

        public ViewResult Index()
        {
            return View(detalle_tiposRepository.AllIncluding(detalle_tipos => detalle_tipos.CASO_USO_DETALLES, detalle_tipos => detalle_tipos.PROYECTO_DETALLES, detalle_tipos => detalle_tipos.REQUERIMIENTO_DETALLES));
        }

        //
        // GET: /DETALLE_TIPOS/Details/5

        public ViewResult Details(decimal id)
        {
            return View(detalle_tiposRepository.Find(id));
        }

        //
        // GET: /DETALLE_TIPOS/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /DETALLE_TIPOS/Create

        [HttpPost]
        public ActionResult Create(DETALLE_TIPOS detalle_tipos)
        {
            if (ModelState.IsValid) {
                detalle_tiposRepository.InsertOrUpdate(detalle_tipos);
                detalle_tiposRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /DETALLE_TIPOS/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(detalle_tiposRepository.Find(id));
        }

        //
        // POST: /DETALLE_TIPOS/Edit/5

        [HttpPost]
        public ActionResult Edit(DETALLE_TIPOS detalle_tipos)
        {
            if (ModelState.IsValid) {
                detalle_tiposRepository.InsertOrUpdate(detalle_tipos);
                detalle_tiposRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /DETALLE_TIPOS/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(detalle_tiposRepository.Find(id));
        }

        //
        // POST: /DETALLE_TIPOS/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            detalle_tiposRepository.Delete(id);
            detalle_tiposRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                detalle_tiposRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

