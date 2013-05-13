using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CASEPro.Models;

namespace CASEPro.Controllers
{   
    public class REQUERIMIENTO_CATEGORIASController : Controller
    {
		private readonly IREQUERIMIENTO_CATEGORIASRepository requerimiento_categoriasRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public REQUERIMIENTO_CATEGORIASController() : this(new REQUERIMIENTO_CATEGORIASRepository())
        {
        }

        public REQUERIMIENTO_CATEGORIASController(IREQUERIMIENTO_CATEGORIASRepository requerimiento_categoriasRepository)
        {
			this.requerimiento_categoriasRepository = requerimiento_categoriasRepository;
        }

        //
        // GET: /REQUERIMIENTO_CATEGORIAS/

        public ViewResult Index()
        {
            return View(requerimiento_categoriasRepository.AllIncluding(requerimiento_categorias => requerimiento_categorias.REQUERIMIENTOS));
        }

        //
        // GET: /REQUERIMIENTO_CATEGORIAS/Details/5

        public ViewResult Details(decimal id)
        {
            return View(requerimiento_categoriasRepository.Find(id));
        }

        //
        // GET: /REQUERIMIENTO_CATEGORIAS/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /REQUERIMIENTO_CATEGORIAS/Create

        [HttpPost]
        public ActionResult Create(REQUERIMIENTO_CATEGORIAS requerimiento_categorias)
        {
            if (ModelState.IsValid) {
                requerimiento_categoriasRepository.InsertOrUpdate(requerimiento_categorias);
                requerimiento_categoriasRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /REQUERIMIENTO_CATEGORIAS/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(requerimiento_categoriasRepository.Find(id));
        }

        //
        // POST: /REQUERIMIENTO_CATEGORIAS/Edit/5

        [HttpPost]
        public ActionResult Edit(REQUERIMIENTO_CATEGORIAS requerimiento_categorias)
        {
            if (ModelState.IsValid) {
                requerimiento_categoriasRepository.InsertOrUpdate(requerimiento_categorias);
                requerimiento_categoriasRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /REQUERIMIENTO_CATEGORIAS/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(requerimiento_categoriasRepository.Find(id));
        }

        //
        // POST: /REQUERIMIENTO_CATEGORIAS/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            requerimiento_categoriasRepository.Delete(id);
            requerimiento_categoriasRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                requerimiento_categoriasRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

