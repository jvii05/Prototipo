using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CASEPro.Models;

namespace CASEPro.Controllers
{   
    public class DOCUMENTOesController : Controller
    {
		private readonly IDOCUMENTORepository documentoRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public DOCUMENTOesController() : this(new DOCUMENTORepository())
        {
        }

        public DOCUMENTOesController(IDOCUMENTORepository documentoRepository)
        {
			this.documentoRepository = documentoRepository;
        }

        //
        // GET: /DOCUMENTOes/

        public ViewResult Index()
        {
            return View(documentoRepository.All);
        }

        //
        // GET: /DOCUMENTOes/Details/5

        public ViewResult Details(decimal id)
        {
            return View(documentoRepository.Find(id));
        }

        //
        // GET: /DOCUMENTOes/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /DOCUMENTOes/Create

        [HttpPost]
        public ActionResult Create(DOCUMENTO documento)
        {
            if (ModelState.IsValid) {
                documentoRepository.InsertOrUpdate(documento);
                documentoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /DOCUMENTOes/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(documentoRepository.Find(id));
        }

        //
        // POST: /DOCUMENTOes/Edit/5

        [HttpPost]
        public ActionResult Edit(DOCUMENTO documento)
        {
            if (ModelState.IsValid) {
                documentoRepository.InsertOrUpdate(documento);
                documentoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /DOCUMENTOes/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(documentoRepository.Find(id));
        }

        //
        // POST: /DOCUMENTOes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            documentoRepository.Delete(id);
            documentoRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                documentoRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

