using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CASEPro.Models;

namespace CASEPro.Controllers
{   
    public class PROYECTOesController : Controller
    {
		private readonly IPROYECTORepository proyectoRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public PROYECTOesController() : this(new PROYECTORepository())
        {
        }

        public PROYECTOesController(IPROYECTORepository proyectoRepository)
        {
			this.proyectoRepository = proyectoRepository;
        }

        //
        // GET: /PROYECTOes/

        public ViewResult Index()
        {
            return View(proyectoRepository.AllIncluding(proyecto => proyecto.PROYECTO_DETALLES, proyecto => proyecto.REQUERIMIENTOS));
        }

        //
        // GET: /PROYECTOes/Details/5

        public ViewResult Details(decimal id)
        {
            return View(proyectoRepository.Find(id));
        }

        //
        // GET: /PROYECTOes/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /PROYECTOes/Create

        [HttpPost]
        public ActionResult Create(PROYECTO proyecto)
        {
            if (ModelState.IsValid) {
                proyectoRepository.InsertOrUpdate(proyecto);
                proyectoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /PROYECTOes/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(proyectoRepository.Find(id));
        }

        //
        // POST: /PROYECTOes/Edit/5

        [HttpPost]
        public ActionResult Edit(PROYECTO proyecto)
        {
            if (ModelState.IsValid) {
                proyectoRepository.InsertOrUpdate(proyecto);
                proyectoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /PROYECTOes/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(proyectoRepository.Find(id));
        }

        //
        // POST: /PROYECTOes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            proyectoRepository.Delete(id);
            proyectoRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                proyectoRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

