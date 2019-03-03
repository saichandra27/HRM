using HRM.Data.DbContext;
using HRM.Data.Entities.Job;
using HRM.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HRM.Services.Services
{
    public class JobService : IJobService
    {
        private HRMDbContext _dbcontext;

        public JobService(HRMDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IQueryable<JobTitle> Read()
        {
            var result = _dbcontext.JobTitle.ToList().Select(jbtype => new JobTitle
            {
                ID = jbtype.ID,
                Title = jbtype.Title,
                JobDescription = jbtype.JobDescription,
                Notes = jbtype.Notes,
                Attachments = jbtype.Attachments,
                Created = jbtype.Created,
                Createdby = jbtype.Createdby,
                Modified = jbtype.Modified,
                Modifiedby = jbtype.Modifiedby
            }).AsQueryable();
            return result;
        }

        public JobTitle GetJobTitleById(int Id)
        {
            var result = _dbcontext.JobTitle.Where(x => x.ID == Id).FirstOrDefault();
            return result;
        }

        public IQueryable<PayGrade> ReadPayGrade()
        {
            var result = _dbcontext.PayGrade.ToList().Select(paygrade => new PayGrade
            {
                ID = paygrade.ID,
                Title = paygrade.Title,
                Currency = paygrade.Currency,
                MinSalary = paygrade.MinSalary,
                MaxSalary = paygrade.MaxSalary,
                Attachments = paygrade.Attachments
            }).AsQueryable();
            return result;
        }

        public PayGrade GetPayGradeById(int Id)
        {
            var result = _dbcontext.PayGrade.Where(x => x.ID == Id).FirstOrDefault();
            return result;
        }

        public IQueryable<EmploymentStatus> ReadEmploymentStatus()
        {
            var result = _dbcontext.EmploymentStatus.ToList().Select(empstatus => new EmploymentStatus
            {
                ID = empstatus.ID,
                Title = empstatus.Title,
                Attachments = empstatus.Attachments
            }).AsQueryable();
            return result;
        }

        public EmploymentStatus GetEmploymentStatusById(int Id)
        {
            var result = _dbcontext.EmploymentStatus.Where(x => x.ID == Id).FirstOrDefault();
            return result;
        }

        public IQueryable<JobCategory> ReadJobCategory()
        {
            var result = _dbcontext.JobCategory.ToList().Select(empstatus => new JobCategory
            {
                ID = empstatus.ID,
                Title = empstatus.Title,
                Attachments = empstatus.Attachments
            }).AsQueryable();
            return result;
        }

        public IQueryable<JobShifts> ReadJobShits()
        {
            var result = _dbcontext.JobCategory.ToList().Select(empstatus => new JobShifts
            {
                ID = empstatus.ID,
                Title = empstatus.Title,
                Attachments = empstatus.Attachments
            }).AsQueryable();
            return result;
        }

        public JobCategory GetJobCategoryById(int Id)
        {
            var result = _dbcontext.JobCategory.Where(x => x.ID == Id).FirstOrDefault();
            return result;
        }

        public JobShifts GetJobShitsById(int Id)
        {
            var result = _dbcontext.JobShifts.Where(x => x.ID == Id).FirstOrDefault();
            return result;
        }

    }
}
