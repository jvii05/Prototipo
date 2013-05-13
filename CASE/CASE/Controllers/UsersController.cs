using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CASE.Models;

namespace CASE.Controllers
{   
    public class USERsController : Controller
    {
		private readonly IUSERRepository userRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public USERsController() : this(new USERRepository())
        {
        }

        public USERsController(IUSERRepository userRepository)
        {
			this.userRepository = userRepository;
        }

        //
        // GET: /USERs/

        public ViewResult Index()
        {
            return View(userRepository.All);
        }

        //
        // GET: /USERs/Details/5

        public ViewResult Details(decimal id)
        {
            return View(userRepository.Find(id));
        }

        //
        // GET: /USERs/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /USERs/Create

        [HttpPost]
        public ActionResult Create(USER user)
        {
            if (ModelState.IsValid) {
                userRepository.InsertOrUpdate(user);
                userRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /USERs/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(userRepository.Find(id));
        }

        //
        // POST: /USERs/Edit/5

        [HttpPost]
        public ActionResult Edit(USER user)
        {
            if (ModelState.IsValid) {
                userRepository.InsertOrUpdate(user);
                userRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /USERs/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(userRepository.Find(id));
        }

        //
        // POST: /USERs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            userRepository.Delete(id);
            userRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                userRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

