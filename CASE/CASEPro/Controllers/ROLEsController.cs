using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CASEPro.Models;

namespace CASEPro.Controllers
{   
    public class ROLEsController : Controller
    {
		private readonly IROLERepository roleRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ROLEsController() : this(new ROLERepository())
        {
        }

        public ROLEsController(IROLERepository roleRepository)
        {
			this.roleRepository = roleRepository;
        }

        //
        // GET: /ROLEs/

        public ViewResult Index()
        {
            return View(roleRepository.AllIncluding(role => role.OPERACIONES));
        }

        //
        // GET: /ROLEs/Details/5

        public ViewResult Details(decimal id)
        {
            return View(roleRepository.Find(id));
        }

        //
        // GET: /ROLEs/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ROLEs/Create

        [HttpPost]
        public ActionResult Create(ROLE role)
        {
            if (ModelState.IsValid) {
                roleRepository.InsertOrUpdate(role);
                roleRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /ROLEs/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(roleRepository.Find(id));
        }

        //
        // POST: /ROLEs/Edit/5

        [HttpPost]
        public ActionResult Edit(ROLE role)
        {
            if (ModelState.IsValid) {
                roleRepository.InsertOrUpdate(role);
                roleRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /ROLEs/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(roleRepository.Find(id));
        }

        //
        // POST: /ROLEs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            roleRepository.Delete(id);
            roleRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                roleRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

