using JuliePro_DataAccess.Repository.IRepository;
using JuliePro_Models.Models;
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
        public IActionResult Index()
        {
            IEnumerable<Trainer> TrainerList = _unitOfWork.Trainer.GetAll(includeProperties:"Speciality");

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
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*IFormCollection collection*/Trainer trainer)
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
                _unitOfWork.Trainer.Add(trainer);

                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return this.View(trainer);
        }
    }

    // GET: TrainerController/Edit/5
    //public ActionResult Edit(int id)
    //{
    //    return View();
    //}

    //// POST: TrainerController/Edit/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Edit(int id, IFormCollection collection)
    //{
    //    try
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}

    //// GET: TrainerController/Delete/5
    //public ActionResult Delete(int id)
    //{
    //    return View();
    //}

    //// POST: TrainerController/Delete/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Delete(int id, IFormCollection collection)
    //{
    //    try
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}
    //GET DELETE
   
}


