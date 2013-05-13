using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CASEPro.Models;

namespace CASEPro.Controllers
{   
    public class CASOS_USOSController : Controller
    {
		private readonly ICASOS_USOSRepository casos_usosRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public CASOS_USOSController() : this(new CASOS_USOSRepository())
        {
        }

        public CASOS_USOSController(ICASOS_USOSRepository casos_usosRepository)
        {
			this.casos_usosRepository = casos_usosRepository;
        }

        //
        // GET: /CASOS_USOS/

        public ViewResult Index()
        {
            return View(casos_usosRepository.AllIncluding(casos_usos => casos_usos.CASO_USO_DETALLES, casos_usos => casos_usos.REQUERIMIENTOS));
        }

        //
        // GET: /CASOS_USOS/Details/5

        public ViewResult Details(decimal id)
        {
            return View(casos_usosRepository.Find(id));
        }

        //
        // GET: /CASOS_USOS/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /CASOS_USOS/Create

        [HttpPost]
        public ActionResult Create(CASOS_USOS casos_usos)
        {
            if (ModelState.IsValid) {
                casos_usosRepository.InsertOrUpdate(casos_usos);
                casos_usosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /CASOS_USOS/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(casos_usosRepository.Find(id));
        }

        //
        // POST: /CASOS_USOS/Edit/5

        [HttpPost]
        public ActionResult Edit(CASOS_USOS casos_usos)
        {
            if (ModelState.IsValid) {
                casos_usosRepository.InsertOrUpdate(casos_usos);
                casos_usosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /CASOS_USOS/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(casos_usosRepository.Find(id));
        }

        //
        // POST: /CASOS_USOS/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            casos_usosRepository.Delete(id);
            casos_usosRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                casos_usosRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

