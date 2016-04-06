using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using DEME.BizTalk.Assistant.Models;
using DEME.BizTalk.Assistant.Models.Database.Context;

namespace DEME.BizTalk.Assistant.Controllers
{
    public class BusinessProcessController : Controller
    {
        private AssistantContext _context;

        public BusinessProcessController(AssistantContext context)
        {
            _context = context;    
        }

        // GET: BusinessProcesses
        public IActionResult Index()
        {
            return View(_context.BusinessProcessDbSet.ToList());
        }

        // GET: BusinessProcesses/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BusinessProcess businessProcess = _context.BusinessProcessDbSet.Single(m => m.Id == id);
            if (businessProcess == null)
            {
                return HttpNotFound();
            }

            return View(businessProcess);
        }

        // GET: BusinessProcesses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessProcesses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BusinessProcess businessProcess)
        {
            if (ModelState.IsValid)
            {
                _context.BusinessProcessDbSet.Add(businessProcess);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(businessProcess);
        }

        // GET: BusinessProcesses/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BusinessProcess businessProcess = _context.BusinessProcessDbSet.Single(m => m.Id == id);
            if (businessProcess == null)
            {
                return HttpNotFound();
            }
            return View(businessProcess);
        }

        // POST: BusinessProcesses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BusinessProcess businessProcess)
        {
            if (ModelState.IsValid)
            {
                _context.Update(businessProcess);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(businessProcess);
        }

        // GET: BusinessProcesses/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BusinessProcess businessProcess = _context.BusinessProcessDbSet.Single(m => m.Id == id);
            if (businessProcess == null)
            {
                return HttpNotFound();
            }

            return View(businessProcess);
        }

        // POST: BusinessProcesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            BusinessProcess businessProcess = _context.BusinessProcessDbSet.Single(m => m.Id == id);
            _context.BusinessProcessDbSet.Remove(businessProcess);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
