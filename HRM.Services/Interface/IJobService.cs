using HRM.Data.Entities.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Interface
{
    public interface IJobService
    {
        IQueryable<JobTitle> Read();
        IQueryable<PayGrade> ReadPayGrade();
        IQueryable<EmploymentStatus> ReadEmploymentStatus();
        IQueryable<JobCategory> ReadJobCategory();
        IQueryable<JobShifts> ReadJobShits();
        JobTitle GetJobTitleById(int Id);
        PayGrade GetPayGradeById(int Id);
        EmploymentStatus GetEmploymentStatusById(int Id);
        JobCategory GetJobCategoryById(int Id);
        JobShifts GetJobShitsById(int Id);
    }
}
