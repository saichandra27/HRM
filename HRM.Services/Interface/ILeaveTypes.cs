using HRM.Data.Entities.Leaves;
using HRM.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace HRM.Interface
{
    public interface ILeaveTypesService
    {
        IQueryable<LeaveTypeViewModel> Read();
        LeaveTypes GetItemById(int Id);
    }
}
