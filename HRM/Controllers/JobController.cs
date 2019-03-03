using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using HRM.Services;
using System;
using HRM.Common;
using HRM.Data.Entities.Job;
using HRM.Interface;
using System.Web;
using System.IO;

namespace HRM.Controllers
{
    [Authorize(Roles = "SystemAdmin,Job")]
    public class JobController : Controller
    {
        private IJobService _jobService;
        DbContextHelper _dbcontexthelper;

        public JobController(IJobService jobService)
        {
            _dbcontexthelper = new DbContextHelper();
            _jobService = jobService;
        }
        // GET: Job

        #region JobTitle
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JobTitlePopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_jobService.Read().ToDataSourceResult(request));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult JobTitlePopup_Create([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
        {
            if (jbtitle != null && ModelState.IsValid)
            {
                jbtitle.Created = DateTime.Now;
                jbtitle.Createdby = AppSession.UserId;
                _dbcontexthelper.AttachToContext(jbtitle);
            }

            return Json(new[] { jbtitle }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult JobTitlePopup_Update([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
        {
            if (jbtitle != null && ModelState.IsValid)
            {
                var _dt = _jobService.GetJobTitleById(jbtitle.ID);
                jbtitle.Created = _dt.Created;
                jbtitle.Createdby = _dt.Createdby;
                _dbcontexthelper.AttachToContext(jbtitle);
            }
            var _dt1 = _jobService.Read();
            return Json(new[] { jbtitle }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            //return Json(new[] { jbtitle }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult JobTitlePopup_Destroy([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
        {
            if (jbtitle != null)
            {
                _dbcontexthelper.DeleteEntity(jbtitle);
            }

            return Json(new[] { jbtitle }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region PayGrade
        public ActionResult PayGrade()
        {
            return View();
        }
        public ActionResult PayGradePopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_jobService.ReadPayGrade().ToDataSourceResult(request));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PayGradePopup_Create([DataSourceRequest] DataSourceRequest request, PayGrade paygrade)
        {
            if (paygrade != null && ModelState.IsValid)
            {
                paygrade.Created = DateTime.Now;
                paygrade.Createdby = AppSession.UserId;
                _dbcontexthelper.AttachToContext(paygrade);
            }

            return Json(new[] { paygrade }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PayGradePopup_Update([DataSourceRequest] DataSourceRequest request, PayGrade paygrade)
        {
            if (paygrade != null && ModelState.IsValid)
            {
                paygrade.Created = _jobService.GetJobTitleById(paygrade.ID).Created;
                paygrade.Createdby = _jobService.GetJobTitleById(paygrade.ID).Createdby;
                _dbcontexthelper.AttachToContext(paygrade);
            }

            return Json(new[] { _jobService.Read() }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PayGradePopup_Destroy([DataSourceRequest] DataSourceRequest request, PayGrade paygrade)
        {
            if (paygrade != null)
            {
                _dbcontexthelper.DeleteEntity(paygrade);
            }

            return Json(new[] { paygrade }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region EmploymentStatus
        public ActionResult EmploymentStatus()
        {
            return View();
        }
        public ActionResult EmploymentStatusPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_jobService.ReadEmploymentStatus().ToDataSourceResult(request));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EmploymentStatusPopup_Create([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
        {
            if (jbtitle != null && ModelState.IsValid)
            {
                jbtitle.Created = DateTime.Now;
                jbtitle.Createdby = AppSession.UserId;
                _dbcontexthelper.AttachToContext(jbtitle);
            }

            return Json(new[] { _jobService.Read() }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EmploymentStatusPopup_Update([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
        {
            if (jbtitle != null && ModelState.IsValid)
            {
                jbtitle.Created = _jobService.GetJobTitleById(jbtitle.ID).Created;
                jbtitle.Createdby = _jobService.GetJobTitleById(jbtitle.ID).Createdby;
                _dbcontexthelper.AttachToContext(jbtitle);
            }

            return Json(new[] { _jobService.Read() }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EmploymentStatusPopup_Destroy([DataSourceRequest] DataSourceRequest request, JobTitle leavetype)
        {
            if (leavetype != null)
            {
                _dbcontexthelper.DeleteEntity(leavetype);
            }

            return Json(new[] { leavetype }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region JobCategory
        public ActionResult JobCategory()
        {
            return View();
        }
        public ActionResult JobCategoryPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_jobService.ReadJobCategory().ToDataSourceResult(request));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult JobCategoryPopup_Create([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
        {
            if (jbtitle != null && ModelState.IsValid)
            {
                jbtitle.Created = DateTime.Now;
                jbtitle.Createdby = AppSession.UserId;
                _dbcontexthelper.AttachToContext(jbtitle);
            }

            return Json(new[] { _jobService.Read() }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult JobCategoryPopup_Update([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
        {
            if (jbtitle != null && ModelState.IsValid)
            {
                jbtitle.Created = _jobService.GetJobTitleById(jbtitle.ID).Created;
                jbtitle.Createdby = _jobService.GetJobTitleById(jbtitle.ID).Createdby;
                _dbcontexthelper.AttachToContext(jbtitle);
            }

            return Json(new[] { _jobService.Read() }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult JobCategoryPopup_Destroy([DataSourceRequest] DataSourceRequest request, JobTitle leavetype)
        {
            if (leavetype != null)
            {
                _dbcontexthelper.DeleteEntity(leavetype);
            }

            return Json(new[] { leavetype }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region JobShift
        public ActionResult JobShift()
        {
            return View();
        }
        public ActionResult JobShiftPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_jobService.ReadJobShits().ToDataSourceResult(request));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult JobShiftPopup_Create([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
        {
            if (jbtitle != null && ModelState.IsValid)
            {
                jbtitle.Created = DateTime.Now;
                jbtitle.Createdby = AppSession.UserId;
                _dbcontexthelper.AttachToContext(jbtitle);
            }

            return Json(new[] { _jobService.Read() }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult JobShiftPopup_Update([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
        {
            if (jbtitle != null && ModelState.IsValid)
            {
                jbtitle.Created = _jobService.GetJobTitleById(jbtitle.ID).Created;
                jbtitle.Createdby = _jobService.GetJobTitleById(jbtitle.ID).Createdby;
                _dbcontexthelper.AttachToContext(jbtitle);
            }

            return Json(new[] { _jobService.Read() }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult JobShiftPopup_Destroy([DataSourceRequest] DataSourceRequest request, JobTitle leavetype)
        {
            if (leavetype != null)
            {
                _dbcontexthelper.DeleteEntity(leavetype);
            }

            return Json(new[] { leavetype }.ToDataSourceResult(request, ModelState));
        }
        #endregion

       
    }
}