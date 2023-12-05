using GestionAssurance.ApplicationCore.Domain;
using GestionAssurance.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionAssurance.UI.Web.Controllers
{
    public class ExpertiseController : Controller
    {
        private readonly ISinistreService sinistreService;
        private readonly IExpertService expertService;
        private readonly IExpertiseService expertiseService;
        private readonly IAssuranceService assuranceService;

        public ExpertiseController(ISinistreService sinistreService, IExpertService expertService, IExpertiseService expertiseService, IAssuranceService assuranceService)
        {
            this.sinistreService = sinistreService;
            this.expertService = expertService;
            this.expertiseService = expertiseService;
            this.assuranceService = assuranceService;
        }



        // GET: ExpertiseController
        public ActionResult Index(TypeAssurance? typeAssurance)
        {
            if (typeAssurance == null)
            {
                return View(expertiseService.GetAll().OrderBy(e => e.DateExpertise.Date).ToList()); ;
            }else
                return View(expertiseService.GetMany(e => e.Sinistre.Assurance.Type == typeAssurance).OrderBy(e => e.DateExpertise.Date).ToList());
        }

        // GET: ExpertiseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExpertiseController/Create
        public ActionResult Create()
        {
            var sinistres = sinistreService.GetAll().Select(s => new { s.SinistreId, s.Description });
            var experts = expertService.GetAll().Select(e => new { e.Id, e.Nom });
            ViewBag.SinistreFK = new SelectList(sinistres, "SinistreId", "Description");
            ViewBag.ExpertFK = new SelectList(experts, "Id", "Nom");
            return View();
        }

        // POST: ExpertiseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expertise expertise)
        {
            try
            {
                expertiseService.Add(expertise);
                expertiseService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpertiseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExpertiseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpertiseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExpertiseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
