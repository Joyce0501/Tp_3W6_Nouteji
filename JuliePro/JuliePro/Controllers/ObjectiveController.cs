using JuliePro_DataAccess.Repository.IRepository;
using JuliePro_Models.Models;
using JuliePro_Models.ViewModels;
using JuliePro_Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuliePro.Controllers
{
    public class ObjectiveController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ObjectiveController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ObjectiveService _service;

        public ObjectiveController(IUnitOfWork unitOfWork, ILogger<ObjectiveController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _service = new ObjectiveService(this.ModelState, _unitOfWork);
        }

        public IActionResult Index(int Id)
        {
            return View("CustomerTracking", "Customer");
        }

        public async Task<IActionResult> ShowO()
        {
            IEnumerable <Customer> Customers= await _unitOfWork.Customer.GetAllAsync();
            return View(Customers);
        }

        public async Task<IActionResult> Create(int Id)
        {
            Objective objective = new Objective();
            Customer customer = await _unitOfWork.Customer.FirstOrDefaultAsync(c => c.Id == Id);

            ObjectiveVM objectiveVM = new ObjectiveVM()
            {
                Objective = objective,
                CustomerName = customer.FirstName + " " + customer.LastName,
                CustomerId = Id

            };
            return View(objectiveVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ObjectiveVM objectiveVM)
        {

            Objective objective = objectiveVM.Objective;

            if (!_service.CreateObjective(objective))
            {
                // Ajouter à la BD
                ModelState.AddModelError("", "Complete the objectives first");
                return View(objectiveVM);
            }
            return RedirectToAction("CustomerCard", "Customer", new { Id = objectiveVM.Objective.Customer_Id });


        }
    }
}
