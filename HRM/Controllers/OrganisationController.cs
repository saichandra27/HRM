using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using HRM.Services;
using System;
using HRM.Common;
using HRM.Data.Entities.Job;
using HRM.Interface;


namespace HRM.Controllers
{
    public class OrganisationController : Controller
    {
        // GET: Organisation
        private IJobService _jobService;
        DbContextHelper _dbcontexthelper;
        #region Location
        public ActionResult Location()
        {
            return View();
        }
        public ActionResult LocationPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_jobService.Read().ToDataSourceResult(request));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LocationPopup_Create([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
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
        public ActionResult LocationPopup_Update([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
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
        public ActionResult LocationPopup_Destroy([DataSourceRequest] DataSourceRequest request, JobTitle leavetype)
        {
            if (leavetype != null)
            {
                _dbcontexthelper.DeleteEntity(leavetype);
            }

            return Json(new[] { leavetype }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region Nationalities
        public ActionResult Nationalities()
        {
            return View();
        }
        public ActionResult NationalitiesPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_jobService.Read().ToDataSourceResult(request));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult NationalitiesPopup_Create([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
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
        public ActionResult NationalitiesPopup_Update([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
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
        public ActionResult NationalitiesPopup_Destroy([DataSourceRequest] DataSourceRequest request, JobTitle leavetype)
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