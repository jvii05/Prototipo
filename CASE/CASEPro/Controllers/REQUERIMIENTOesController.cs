using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CASEPro.Models;

namespace CASEPro.Controllers
{   
    public class REQUERIMIENTOesController : Controller
    {
		private readonly IREQUERIMIENTORepository requerimientoRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public REQUERIMIENTOesController() : this(new REQUERIMIENTORepository())
        {
        }

        public REQUERIMIENTOesController(IREQUERIMIENTORepository requerimientoRepository)
        {
			this.requerimientoRepository = requerimientoRepository;
        }

        //
        // GET: /REQUERIMIENTOes/

        public ViewResult Index()
        {
            return View(requerimientoRepository.AllIncluding(requerimiento => requerimiento.DOCUMENTOS, requerimiento => requerimiento.REQUERIMIENTO_DETALLES, requerimiento => requerimiento.CASOS_USOS));
        }

        //
        // GET: /REQUERIMIENTOes/Details/5

        public ViewResult Details(decimal id)
        {
            return View(requerimientoRepository.Find(id));
        }

        //
        // GET: /REQUERIMIENTOes/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /REQUERIMIENTOes/Create

        [HttpPost]
        public ActionResult Create(REQUERIMIENTO requerimiento)
        {
            if (ModelState.IsValid) {
                requerimientoRepository.InsertOrUpdate(requerimiento);
                requerimientoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /REQUERIMIENTOes/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(requerimientoRepository.Find(id));
        }

        //
        // POST: /REQUERIMIENTOes/Edit/5

        [HttpPost]
        public ActionResult Edit(REQUERIMIENTO requerimiento)
        {
            if (ModelState.IsValid) {
                requerimientoRepository.InsertOrUpdate(requerimiento);
                requerimientoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /REQUERIMIENTOes/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(requerimientoRepository.Find(id));
        }

        //
        // POST: /REQUERIMIENTOes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            requerimientoRepository.Delete(id);
            requerimientoRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                requerimientoRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

