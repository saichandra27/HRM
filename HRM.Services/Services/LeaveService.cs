using HRM.Data.DbContext;
using HRM.Data.Entities;
using HRM.Data.Entities.Leaves;
using HRM.Data.Models;
using HRM.Interface;
using System.Collections.Generic;
using System.Linq;

namespace HRM.Services
{
    public class LeaveTypesService : ILeaveTypesService
    {
        private HRMDbContext _dbcontext;
        public LeaveTypesService(HRMDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IQueryable<LeaveTypeViewModel> Read()
        {
           var result = _dbcontext.LeaveTypes.Select(leavetype => new LeaveTypeViewModel
            {
                ID = leavetype.ID,
                Title = leavetype.Title,
            }).AsQueryable();
            return result;
        }
       
        public LeaveTypes GetItemById(int Id)
        {
            var result = _dbcontext.LeaveTypes.Where(x => x.ID == Id).FirstOrDefault();
            return result;
        }
    }
}
