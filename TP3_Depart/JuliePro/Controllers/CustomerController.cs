using JuliePro_DataAccess.Repository.IRepository;
using JuliePro_Models.ViewModels;
using JuliePro_Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuliePro.Controllers
{
  public class CustomerController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;

    public CustomerController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public IActionResult OurTrainers()
    {
      OurTrainersVM ourTrainersVM = new OurTrainersVM()
      {
        Trainers = _unitOfWork.Trainer.GetAllActive(),
        Specialities = _unitOfWork.Speciality.GetAll()
      };
      return View(ourTrainersVM);
    }


  }
}
