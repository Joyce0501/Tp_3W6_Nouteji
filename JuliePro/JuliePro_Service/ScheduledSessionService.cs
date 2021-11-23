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
    public class ScheduledSessionService : IScheduledSessionService
    {

        private readonly IUnitOfWork _unitOfWork;

        public ScheduledSessionService( IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public IEnumerable<ScheduledSession> scheduledSessions()
        {
            return _unitOfWork.ScheduledSession.GetAll();
        }

        public bool CreateScheduledSession(ScheduledSession ScheduledSessionToCreate)
        {
            if (_unitOfWork.ScheduledSession.GetAll(s => s.Customer_Id == ScheduledSessionToCreate.Customer_Id && !s.Complete).Count() > 4)
                    return false;
            try
            {
                _unitOfWork.ScheduledSession.AddAsync(ScheduledSessionToCreate);
                _unitOfWork.ScheduledSession.SaveAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

      
    }

    public interface IScheduledSessionService
    {
        bool CreateScheduledSession(ScheduledSession ScheduledSessionToCreate);
        IEnumerable<ScheduledSession> scheduledSessions();
    }

}
