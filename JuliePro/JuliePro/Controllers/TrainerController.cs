using JuliePro_DataAccess.Repository.IRepository;
using JuliePro_Models.Models;
using JuliePro_Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuliePro.Controllers
{
    public class TrainerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TrainerController> _logger;

        public TrainerController(IUnitOfWork unitOfWork, ILogger<TrainerController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Trainer> TrainerList = await _unitOfWork.Trainer.GetAllAsync(includeProperties:"Speciality");

            return View(TrainerList);
        }

        // GET: TrainerController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: TrainerController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: TrainerController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*IFormCollection collection*/Trainer trainer)
        {
            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
            if (ModelState.IsValid)
            {
                // Ajouter à la BD

               await _unitOfWork.Trainer.AddAsync(trainer);

                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return this.View(trainer);
        }

        //GET - UPSERT
        public async Task<IActionResult> Upsert(int? id)
        {
            TrainerVM trainerVM = new TrainerVM()
            {
                Trainer = new Trainer()
            };

            if (id == null)
            {
                //CREATE
                return View(trainerVM);
            }
            else
            {
                //EDIT
                trainerVM.Trainer = await _unitOfWork.Trainer.FirstOrDefaultAsync(/*filter: a => a.Id == id, includeProperties: "AuthorDetail"*/);

                if (trainerVM == null)
                {
                    return NotFound();
                }
                return View(trainerVM);
            }

        }

        //POST Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(TrainerVM trainerVM)
        {
            if (trainerVM.Trainer.Id == 0)
            {
                //this is create
                await _unitOfWork.Trainer.AddAsync(trainerVM.Trainer);
            }
            else
            {
                //this is an update
                _unitOfWork.Trainer.Update(trainerVM.Trainer);
            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var obj = await _unitOfWork.Trainer.GetAsync(id.GetValueOrDefault());
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(obj);
        //}

        //POST DELETE
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            var obj = await _unitOfWork.Trainer.GetAsync(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }

            await _unitOfWork.Trainer.RemoveAsync(obj);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}


