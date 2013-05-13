using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CASEPro.Models;

namespace CASEPro.Controllers
{   
    public class USUARIOsController : Controller
    {
		private readonly IUSUARIORepository usuarioRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public USUARIOsController() : this(new USUARIORepository())
        {
        }

        public USUARIOsController(IUSUARIORepository usuarioRepository)
        {
			this.usuarioRepository = usuarioRepository;
        }

        //
        // GET: /USUARIOs/

        public ViewResult Index()
        {
            return View(usuarioRepository.AllIncluding(usuario => usuario.CASOS_USOS, usuario => usuario.REQUERIMIENTOS, usuario => usuario.REQUERIMIENTOS1));
        }

        //
        // GET: /USUARIOs/Details/5

        public ViewResult Details(decimal id)
        {
            return View(usuarioRepository.Find(id));
        }

        //
        // GET: /USUARIOs/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /USUARIOs/Create

        [HttpPost]
        public ActionResult Create(USUARIO usuario)
        {
            if (ModelState.IsValid) {
                usuarioRepository.InsertOrUpdate(usuario);
                usuarioRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /USUARIOs/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(usuarioRepository.Find(id));
        }

        //
        // POST: /USUARIOs/Edit/5

        [HttpPost]
        public ActionResult Edit(USUARIO usuario)
        {
            if (ModelState.IsValid) {
                usuarioRepository.InsertOrUpdate(usuario);
                usuarioRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /USUARIOs/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(usuarioRepository.Find(id));
        }

        //
        // POST: /USUARIOs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            usuarioRepository.Delete(id);
            usuarioRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                usuarioRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

