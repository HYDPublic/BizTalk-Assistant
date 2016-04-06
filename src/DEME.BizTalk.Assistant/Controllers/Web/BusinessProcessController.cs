using AutoMapper;
using DEME.BizTalk.Assistant.Models;
using DEME.BizTalk.Assistant.Models.Database.Repository;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;

namespace DEME.BizTalk.Assistant.Controllers.Web
{
    public class BusinessProcessController : Controller
    {
        private IAssistantRepository _repository;

        public BusinessProcessController(IAssistantRepository repository)
        {
            _repository = repository;
        }

        // GET: BusinessProcesses
        public IActionResult Index()
        {
            //Linq query always true to return everything
            return View(Mapper.Map<IEnumerable<BusinessProcessViewModel>>(_repository.GetAll(b => true)));
        }

        // GET: BusinessProcesses/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BusinessProcessViewModel businessProcess = Mapper.Map<BusinessProcessViewModel>(_repository.GetOne(b => b.Id == id));
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
                _repository.Add(businessProcess);
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

            BusinessProcessViewModel businessProcess = Mapper.Map<BusinessProcessViewModel>(_repository.GetOne(b => b.Id == id));
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
                _repository.Update(businessProcess);
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

            BusinessProcessViewModel businessProcess = Mapper.Map<BusinessProcessViewModel>(_repository.GetOne(b => b.Id == id));
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
            BusinessProcess businessProcess = _repository.GetOne(b => b.Id == id);
            _repository.Remove(businessProcess);
            return RedirectToAction("Index");
        }
    }
}
