using JuliePro.Utility;
using JuliePro_DataAccess.Repository.IRepository;
using JuliePro_Models.Models;
using JuliePro_Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace JuliePro.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CustomerController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public CustomerController(IUnitOfWork unitOfWork, ILogger<CustomerController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Customer()
        {
            IEnumerable<Trainer> Trainers = await _unitOfWork.Trainer.GetAllAsync();

            TrainerVM trainerVM = new TrainerVM()

            {
                Trainer = new Trainer(),
                TrainerList = Trainers.Select(t => new SelectListItem
                {
                    Text = t.FirstName,
                    Value = t.Id.ToString()
                })
            };
            return View(trainerVM);
        }
        public async Task<IActionResult> ShowO()
        {
            CustomerVM CustomerVM = new CustomerVM()
            {
                Customers = await _unitOfWork.Customer.GetAllAsync(),
                ObjectiveList = await _unitOfWork.Objective.GetAllAsync(),
                ScheduledSessionList = await _unitOfWork.ScheduledSession.GetAllAsync(),
                Trainings = await _unitOfWork.Training.GetAllAsync()
            };
            return View(CustomerVM);
        }
        public async Task<IActionResult> CustomerTracking()
        {
            IEnumerable<Customer> CustomerList = await _unitOfWork.Customer.GetAllAsync(includeProperties: "Trainer");

            return View(CustomerList);
        }

        public async Task<IActionResult> CustomerCard(int id)
        {
            CustomerVM CustomerVM = new CustomerVM()
            {
                Customer = await _unitOfWork.Customer.FirstOrDefaultAsync(c => c.Id == id),
                ObjectiveList = await _unitOfWork.Objective.GetAllAsync(o => o.Customer_Id == id),
                ScheduledSessionList = await _unitOfWork.ScheduledSession.GetAllAsync(s => s.Customer_Id == id, includeProperties: "Training")
            };
            return View(CustomerVM);
        }
    }

}
