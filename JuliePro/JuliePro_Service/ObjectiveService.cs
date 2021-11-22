using JuliePro_DataAccess.Repository.IRepository;
using JuliePro_Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Service
{
    public class ObjectiveService :IObjectiveService
    {
        private ModelStateDictionary _modelState;
        private readonly IUnitOfWork _unitOfWork;

        public ObjectiveService(ModelStateDictionary modelState,IUnitOfWork unitOfWork)
        {
            _modelState = modelState;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Objective> Objectives()
        {
            return (IEnumerable<Objective>)_unitOfWork.Objective.GetAllAsync();
        }

        public bool CreateObjective(Objective objectiveToCreate)
        {
            if (Objectives().FirstOrDefault(o => o.AchievedDate == DateTime.MinValue && o.Customer_Id == objectiveToCreate.Customer_Id) != default)
                return false;
            try
            {
                _unitOfWork.Objective.AddAsync(objectiveToCreate);
                _unitOfWork.Objective.SaveAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

    }

    public interface IObjectiveService
    {
        bool CreateObjective(Objective objectiveToCreate);
        IEnumerable<Objective> Objectives();
    }

}
