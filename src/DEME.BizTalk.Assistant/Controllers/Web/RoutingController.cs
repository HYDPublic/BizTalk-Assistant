using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using DEME.BizTalk.Assistant.Models;
using DEME.BizTalk.Assistant.Models.Database.Context;
using AutoMapper;
using DEME.BizTalk.Assistant.Models.Database.Repository;
using System.Collections.Generic;

namespace DEME.BizTalk.Assistant.Controllers.Web
{
    public class RoutingController : Controller
    {
        private IAssistantRepository _repository;

        public RoutingController(IAssistantRepository repository)
        {
            _repository = repository;
        }

        // GET: Routing
        public IActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<RoutingViewModel>>(_repository.GetAllRouting(r => true)));
        }

        // GET: Routing/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            RoutingViewModel routing = Mapper.Map<RoutingViewModel>(_repository.GetOneRouting(m => m.Id == id));
            if (routing == null)
            {
                return HttpNotFound();
            }

            return View(routing);
        }

        // GET: Routing/Create
        public IActionResult Create()
        {
            ViewBag.BusinessProcessSelection = new SelectList(_repository.GetAllBusinessProcesses(bp => true).Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.ToString()
            }), "Value", "Text");
            return View();
        }

        // POST: Routing/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoutingViewModel routing)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(Mapper.Map<Routing>(routing));
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

            RoutingViewModel routing = Mapper.Map<RoutingViewModel>(_repository.GetOneRouting(m => m.Id == id));
            if (routing == null)
            {
                return HttpNotFound();
            }

            ViewBag.BusinessProcessSelection = new SelectList(_repository.GetAllBusinessProcesses(bp => true).Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.ToString()
            }), "Value", "Text");

            return View(routing);
        }

        // POST: Routing/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RoutingViewModel routing)
        {
            //Only Id is set via the page, so get the value alongside the id
            routing.Source = _repository.GetOneBusinessProcess(p => p.Id == routing.Source.Id);
            routing.Destination = _repository.GetOneBusinessProcess(p => p.Id == routing.Destination.Id);
            if (ModelState.IsValid)
            {
                _repository.Update(Mapper.Map<Routing>(routing));
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

            RoutingViewModel routing = Mapper.Map<RoutingViewModel>(_repository.GetOneRouting(m => m.Id == id));
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
            Routing routing = _repository.GetOneRouting(m => m.Id == id);
            _repository.Remove(routing);
            return RedirectToAction("Index");
        }
    }
}
