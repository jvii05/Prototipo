using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CASEPro.Models;

namespace CASEPro.Controllers
{   
    public class CASO_USO_DETALLESController : Controller
    {
		private readonly ICASO_USO_DETALLESRepository caso_uso_detallesRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public CASO_USO_DETALLESController() : this(new CASO_USO_DETALLESRepository())
        {
        }

        public CASO_USO_DETALLESController(ICASO_USO_DETALLESRepository caso_uso_detallesRepository)
        {
			this.caso_uso_detallesRepository = caso_uso_detallesRepository;
        }

        //
        // GET: /CASO_USO_DETALLES/

        public ViewResult Index()
        {
            return View(caso_uso_detallesRepository.All);
        }

        //
        // GET: /CASO_USO_DETALLES/Details/5

        public ViewResult Details(decimal id)
        {
            return View(caso_uso_detallesRepository.Find(id));
        }

        //
        // GET: /CASO_USO_DETALLES/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /CASO_USO_DETALLES/Create

        [HttpPost]
        public ActionResult Create(CASO_USO_DETALLES caso_uso_detalles)
        {
            if (ModelState.IsValid) {
                caso_uso_detallesRepository.InsertOrUpdate(caso_uso_detalles);
                caso_uso_detallesRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /CASO_USO_DETALLES/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(caso_uso_detallesRepository.Find(id));
        }

        //
        // POST: /CASO_USO_DETALLES/Edit/5

        [HttpPost]
        public ActionResult Edit(CASO_USO_DETALLES caso_uso_detalles)
        {
            if (ModelState.IsValid) {
                caso_uso_detallesRepository.InsertOrUpdate(caso_uso_detalles);
                caso_uso_detallesRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /CASO_USO_DETALLES/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(caso_uso_detallesRepository.Find(id));
        }

        //
        // POST: /CASO_USO_DETALLES/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            caso_uso_detallesRepository.Delete(id);
            caso_uso_detallesRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                caso_uso_detallesRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

