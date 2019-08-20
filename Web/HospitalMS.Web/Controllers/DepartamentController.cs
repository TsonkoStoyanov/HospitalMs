using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMS.Web.Controllers
{
    public class DepartmentController : BaseController
    {
        // GET: Departament
        public async Task<IActionResult> All()
        {
            return this.View();
        }

        // GET: Departament/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Departament/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Departament/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(All));
            }
            catch
            {
                return View();
            }
        }

        // GET: Departament/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Departament/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(All));
            }
            catch
            {
                return View();
            }
        }

        // GET: Departament/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Departament/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(All));
            }
            catch
            {
                return View();
            }
        }
    }
}