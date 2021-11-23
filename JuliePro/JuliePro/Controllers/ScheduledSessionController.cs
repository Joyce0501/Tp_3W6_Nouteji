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
    public class ScheduledSessionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ScheduledSessionController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ScheduledSessionService _service;

        public ScheduledSessionController(IUnitOfWork unitOfWork, ILogger<ObjectiveController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            //_logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _service = new ScheduledSessionService( _unitOfWork);
        }

        public IActionResult Index(int Id)
        {
            return View("CustomerTracking", "Customer");
        }

        public async Task<IActionResult> ShowS()
        {
            IEnumerable<ScheduledSession> ScheduledSessions = await _unitOfWork.ScheduledSession.GetAllAsync();
            return View(ScheduledSessions);
        }

        public async Task<IActionResult> Create(int Id)
        {
            ScheduledSession scheduledSession = new ScheduledSession();
            Customer customer = await _unitOfWork.Customer.FirstOrDefaultAsync(c => c.Id == Id);

            ScheduledSessionVM scheduledSessionVM = new ScheduledSessionVM()
            {
                ScheduledSession = scheduledSession,
                CustomerName = customer.FirstName + " " + customer.LastName,
                CustomerId = Id

            };
            return View(scheduledSessionVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ScheduledSessionVM scheduledSessionVM)
        {

            ScheduledSession scheduledSession = scheduledSessionVM.ScheduledSession;

            if (!_service.CreateScheduledSession(scheduledSession))
            {
                // Ajouter à la BD
                ModelState.AddModelError("", "Complete those ScheduledSessions first");
                return View(scheduledSessionVM);
            }
            return RedirectToAction("CustomerCard", "Customer", new { Id = scheduledSessionVM.ScheduledSession.Customer_Id });


        }
    }
}

