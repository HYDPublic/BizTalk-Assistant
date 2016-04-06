using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using DEME.BizTalk.Assistant.Models;
using DEME.BizTalk.Assistant.Models.Database.Context;

namespace DEME.BizTalk.Assistant.Controllers.Web
{
    public class RoutingController : Controller
    {
        private AssistantContext _context;

        public RoutingController(AssistantContext context)
        {
            _context = context;    
        }

        // GET: Routing
        public IActionResult Index()
        {
            return View(_context.RoutingDbSet.ToList());
        }

        // GET: Routing/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Routing routing = _context.RoutingDbSet.Single(m => m.Id == id);
            if (routing == null)
            {
                return HttpNotFound();
            }

            return View(routing);
        }

        // GET: Routing/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Routing/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Routing routing)
        {
            if (ModelState.IsValid)
            {
                _context.RoutingDbSet.Add(routing);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(routing);
        }

        // GET: Routing/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Routing routing = _context.RoutingDbSet.Single(m => m.Id == id);
            if (routing == null)
            {
                return HttpNotFound();
            }
            return View(routing);
        }

        // POST: Routing/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Routing routing)
        {
            if (ModelState.IsValid)
            {
                _context.Update(routing);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(routing);
        }

        // GET: Routing/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Routing routing = _context.RoutingDbSet.Single(m => m.Id == id);
            if (routing == null)
            {
                return HttpNotFound();
            }

            return View(routing);
        }

        // POST: Routing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Routing routing = _context.RoutingDbSet.Single(m => m.Id == id);
            _context.RoutingDbSet.Remove(routing);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
