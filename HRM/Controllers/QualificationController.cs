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
    public class QualificationController : Controller
    {
        private IQualificationService _qualificationService;
        DbContextHelper _dbcontexthelper;

        public QualificationController(IQualificationService qualificationService)
        {
            _dbcontexthelper = new DbContextHelper();
            _qualificationService = qualificationService;
        }

        // GET: Qualification
        #region Skills
        public ActionResult Skills()
        {
            return View();
        }
        public ActionResult SkillsPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_qualificationService.Read().ToDataSourceResult(request));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SkillsPopup_Create([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
        {
            if (jbtitle != null && ModelState.IsValid)
            {
                jbtitle.Created = DateTime.Now;
                jbtitle.Createdby = AppSession.UserId;
                _dbcontexthelper.AttachToContext(jbtitle);
            }

            return Json(new[] { _qualificationService.Read() }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SkillsPopup_Update([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
        {
            if (jbtitle != null && ModelState.IsValid)
            {
                jbtitle.Created = _qualificationService.GetSkillTitleById(jbtitle.ID).Created;
                jbtitle.Createdby = _qualificationService.GetSkillTitleById(jbtitle.ID).Createdby;
                _dbcontexthelper.AttachToContext(jbtitle);
            }

            return Json(new[] { _qualificationService.Read() }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SkillsPopup_Destroy([DataSourceRequest] DataSourceRequest request, JobTitle leavetype)
        {
            if (leavetype != null)
            {
                _dbcontexthelper.DeleteEntity(leavetype);
            }

            return Json(new[] { leavetype }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region Education
        public ActionResult Education()
        {
            return View();
        }
        public ActionResult EducationPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_qualificationService.Read().ToDataSourceResult(request));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EducationPopup_Create([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
        {
            if (jbtitle != null && ModelState.IsValid)
            {
                jbtitle.Created = DateTime.Now;
                jbtitle.Createdby = AppSession.UserId;
                _dbcontexthelper.AttachToContext(jbtitle);
            }

            return Json(new[] { _qualificationService.Read() }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EducationPopup_Update([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
        {
            if (jbtitle != null && ModelState.IsValid)
            {
                jbtitle.Created = _qualificationService.GetEducationById(jbtitle.ID).Created;
                jbtitle.Createdby = _qualificationService.GetEducationById(jbtitle.ID).Createdby;
                _dbcontexthelper.AttachToContext(jbtitle);
            }

            return Json(new[] { _qualificationService.Read() }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EducationPopup_Destroy([DataSourceRequest] DataSourceRequest request, JobTitle leavetype)
        {
            if (leavetype != null)
            {
                _dbcontexthelper.DeleteEntity(leavetype);
            }

            return Json(new[] { leavetype }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region Certification
        public ActionResult Certification()
        {
            return View();
        }
        public ActionResult CertificationPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_qualificationService.Read().ToDataSourceResult(request));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CertificationPopup_Create([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
        {
            if (jbtitle != null && ModelState.IsValid)
            {
                jbtitle.Created = DateTime.Now;
                jbtitle.Createdby = AppSession.UserId;
                _dbcontexthelper.AttachToContext(jbtitle);
            }

            return Json(new[] { _qualificationService.Read() }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CertificationPopup_Update([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
        {
            if (jbtitle != null && ModelState.IsValid)
            {
                jbtitle.Created = _qualificationService.GetCertificationById(jbtitle.ID).Created;
                jbtitle.Createdby = _qualificationService.GetCertificationById(jbtitle.ID).Createdby;
                _dbcontexthelper.AttachToContext(jbtitle);
            }

            return Json(new[] { _qualificationService.Read() }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CertificationPopup_Destroy([DataSourceRequest] DataSourceRequest request, JobTitle leavetype)
        {
            if (leavetype != null)
            {
                _dbcontexthelper.DeleteEntity(leavetype);
            }

            return Json(new[] { leavetype }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region Languages
        public ActionResult Languages()
        {
            return View();
        }
        public ActionResult LanguagesPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_qualificationService.Read().ToDataSourceResult(request));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LanguagesPopup_Create([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
        {
            if (jbtitle != null && ModelState.IsValid)
            {
                jbtitle.Created = DateTime.Now;
                jbtitle.Createdby = AppSession.UserId;
                _dbcontexthelper.AttachToContext(jbtitle);
            }

            return Json(new[] { _qualificationService.Read() }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LanguagesPopup_Update([DataSourceRequest] DataSourceRequest request, JobTitle jbtitle)
        {
            if (jbtitle != null && ModelState.IsValid)
            {
                //jbtitle.Created = _qualificationService.GetLanguageById(jbtitle.ID).Created;
                //jbtitle.Createdby = _qualificationService.GetLanguageById(jbtitle.ID).Createdby;
                _dbcontexthelper.AttachToContext(jbtitle);
            }

            return Json(new[] { _qualificationService.Read() }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LanguagesPopup_Destroy([DataSourceRequest] DataSourceRequest request, JobTitle leavetype)
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