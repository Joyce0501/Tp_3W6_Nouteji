using JuliePro_DataAccess.Repository.IRepository;
using JuliePro_Models;
using JuliePro_Models.ViewModels;
using JuliePro_Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JuliePro.Controllers
{
    public class TrainerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
    // permet d'avoir de chemin de la racine du site wwwroot
    private readonly IWebHostEnvironment _webHostEnvironment;

    public TrainerController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
    }

        public IActionResult Index()
        {
            IEnumerable<Trainer> listeTrainer = _unitOfWork.Trainer.GetAll(includeProperties:"Speciality");
            return View(listeTrainer);
        }

    //GET - UPSERT
    public IActionResult Upsert(int? id)
    {
      IEnumerable<Speciality> SpecialityList =  _unitOfWork.Speciality.GetAll();
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
        trainerVM.Trainer = _unitOfWork.Trainer.FirstOrDefault(filter: a => a.Id == id, includeProperties: "Speciality");

        if (trainerVM == null)
        {
          return NotFound();
        }
        return View(trainerVM);
      }

    }

    //POST - UPSERT
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(TrainerVM trainerVM)
    {
      if (ModelState.IsValid)
      {
        var files = HttpContext.Request.Form.Files;
        string webRootPath = _webHostEnvironment.WebRootPath;

        if (trainerVM.Trainer.Id == 0)
        {
          //Creating
          string upload = webRootPath + AppConstants.PhotoPathTrainers;
          string fileName = Guid.NewGuid().ToString();
          string extension = Path.GetExtension(files[0].FileName);

          using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
          {
            files[0].CopyTo(fileStream);
          }

          trainerVM.Trainer.Photo = fileName + extension;

          _unitOfWork.Trainer.Add(trainerVM.Trainer);
        }
        else
        {
          //updating
          var objFromDb = _unitOfWork.Trainer.FirstOrDefault(a => a.Id == trainerVM.Trainer.Id);
          if (files.Count > 0)
          {
            string upload = webRootPath + AppConstants.PhotoPathTrainers;
            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(files[0].FileName);

            if (trainerVM.Trainer.Photo != null)
            {
              var oldFile = Path.Combine(upload, objFromDb.Photo);

              if (System.IO.File.Exists(oldFile))
              {
                System.IO.File.Delete(oldFile);
              }
            }
            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
            {
              files[0].CopyTo(fileStream);
            }

            trainerVM.Trainer.Photo = fileName + extension;
          }
          else
          {
            trainerVM.Trainer.Photo = objFromDb.Photo;
          }

          _unitOfWork.Trainer.Update(trainerVM.Trainer);

          _unitOfWork.Save();
          return RedirectToAction(nameof(Index));
        }
      }

      return View(trainerVM);
    }

    //GET DELETE
    public IActionResult Delete(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }

      var obj = _unitOfWork.Trainer.Get(id.GetValueOrDefault());
      if (obj == null)
      {
        return NotFound();
      }

      return View(obj);
    }

    //POST DELETE
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult DeletePost(int? id)
    {
      var obj = _unitOfWork.Trainer.Get(id.GetValueOrDefault());
      if (obj == null)
      {
        return NotFound();
      }

       _unitOfWork.Trainer.Remove(obj);
      _unitOfWork.Save();

      return RedirectToAction("Index");
    }

    public IActionResult CustomerCard(int id)
    {
      CustomerVM customerVM = new CustomerVM()
      {
        Customer = _unitOfWork.Customer.FirstOrDefault(p => p.Id == id),
        SheduledSessionsList = _unitOfWork.ScheduledSession.GetAll(s => s.Customer_Id == id, includeProperties: "Training")

      };
      return View(customerVM);
    }

  }
}
