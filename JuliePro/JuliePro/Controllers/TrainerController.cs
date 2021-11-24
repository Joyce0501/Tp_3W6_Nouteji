using JuliePro.Utility;
using JuliePro_DataAccess.Repository.IRepository;
using JuliePro_Models.Models;
using JuliePro_Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<TrainerController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TrainerController(IUnitOfWork unitOfWork, ILogger<TrainerController> logger,IWebHostEnvironment webHostEnvironment, IStringLocalizer<HomeController> localizer, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;

        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Trainer> TrainerList = await _unitOfWork.Trainer.GetAllAsync(includeProperties: "Speciality");

            return View(TrainerList);
        }


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
            IEnumerable<Speciality> specialities = await _unitOfWork.Speciality.GetAllAsync();

            TrainerVM trainerVM = new TrainerVM()

            {
                Trainer = new Trainer(),
                SpecialityList = specialities.Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                })
            };

            if (id == null)
            {
                //CREATE
                return View(trainerVM);
            }
            //else
            //{
                //EDIT
                trainerVM.Trainer = await _unitOfWork.Trainer.GetAsync(id.GetValueOrDefault());

                if (trainerVM.Trainer == null)
                {
                    return NotFound();
                }
                return View(trainerVM);
            //}

        }

        //POST Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(TrainerVM trainerVM)
        {
            string webRootPath = _webHostEnvironment.WebRootPath; //Chemin des images de voyage: Travel
            var files = HttpContext.Request.Form.Files; //nouvelle image récupérée

            if (files.Count > 0)
            {
                string fileName = Guid.NewGuid().ToString();// Nom fichier généré, unique
                var uploads = Path.Combine(webRootPath, AppContants.ImagePath);// chemin pour les images
                var extenstion = Path.GetExtension(files[0].FileName); // extraire l'extension du fichier

                if (trainerVM.Trainer.Photo != null)
                {
                    //L'image est modifiée: l'ancienne doit être supprimée
                    var imagePath = Path.Combine(webRootPath, trainerVM.Trainer.Photo.TrimStart('\\'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
                // Create un canal pour transférer le fichier 
                using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extenstion), FileMode.Create))
                {
                    files[0].CopyTo(filesStreams);
                }
                // Composer le nom du fichier avec son extension qui sera enregister dans la BD
                // avec le path relatif à partir du Root
                // sans le path relatif (le path devra être ajouté dans la View)
               trainerVM.Trainer.Photo = fileName + extenstion;
              
            }

            // Ajouter à la BD
            await _unitOfWork.Trainer.AddAsync(trainerVM.Trainer);

            if (trainerVM.Trainer.Id == 0)
            {
                //this is create
                await _unitOfWork.Trainer.AddAsync(trainerVM.Trainer);
                TempData[AppContants.Success] = "The trainer was created.";
                _unitOfWork.Save();


                //_unitOfWork.Trainer.Update(trainerVM.Trainer);
            }
            else
            {
                //this is an update
                //_unitOfWork.Trainer.AddAsync(trainerVM.Trainer);

                _unitOfWork.Trainer.Update(trainerVM.Trainer);
                TempData[AppContants.Success] = "The trainer was updated.";
                _unitOfWork.Save();
            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
          
        }
     
        public async Task<IActionResult> Delete(int? id)
        {
           
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = await _unitOfWork.Trainer.GetAsync(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

            //Trainer trainer = await _unitOfWork.Trainer.FirstOrDefaultAsync(t => t.Id == id);
            //if(trainer == null)
            //{
            //    return NotFound();
            //}
            //return View(trainer);
        }

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

        public async Task<IActionResult> FiltrerAsync()
        {


            TrainerVM trainerVM = new TrainerVM()
            {
                Trainers = await _unitOfWork.Trainer.GetAllAsync(includeProperties: "Speciality"),
                Specialities = await _unitOfWork.Speciality.GetAllAsync(),
            };
            return View(trainerVM);
        }
    }
}


