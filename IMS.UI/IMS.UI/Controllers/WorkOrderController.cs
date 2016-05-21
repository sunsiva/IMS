using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.UI.Controllers
{
    public class WorkOrderController : Controller
    {
        // GET: WorkOrder
        public ActionResult Index()
        {
            return View();
        }

        // GET: WorkOrder temporary for a demo
        public ActionResult IndexTemp()
        {
            return PartialView("_IndexTemp");
        }

        // GET: WorkOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkOrder/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkOrder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorkOrder/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkOrder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorkOrder/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
