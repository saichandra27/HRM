using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using HRM.Services;
using HRM.Data.Models;
using HRM.Interface;
using HRM.Data.Entities.Leaves;
using System;
using HRM.Common;

namespace HRM.Controllers
{
    [Authorize(Roles = "SystemAdmin,Leaves")]
    public class LeaveTypesController : Controller
    {
        private ILeaveTypesService _leaveservice;
        DbContextHelper _dbcontexthelper;

        public LeaveTypesController(ILeaveTypesService leaveservice)
        {
            _dbcontexthelper = new DbContextHelper();
            _leaveservice = leaveservice;
        }
        // GET: LeaveTypes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EditingPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_leaveservice.Read().ToDataSourceResult(request));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, LeaveTypes leavetype)
        {
            if (leavetype != null && ModelState.IsValid)
            {
                leavetype.Created = DateTime.Now;
                leavetype.Createdby = AppSession.UserId;
                _dbcontexthelper.AttachToContext(leavetype);
            }

            return Json(new[] { leavetype }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, LeaveTypes leavetype)
        {
            if (leavetype != null && ModelState.IsValid)
            {
                LeaveTypes lvtype = _leaveservice.GetItemById(leavetype.ID);
                leavetype.Created = lvtype.Created;
                leavetype.Createdby = lvtype.Createdby;
                _dbcontexthelper.AttachToContext(leavetype);
            }

            return Json(new[] { leavetype }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Destroy([DataSourceRequest] DataSourceRequest request, LeaveTypeViewModel leavetype)
        {
            if (leavetype != null)
            {
                _dbcontexthelper.DeleteEntity(leavetype);
            }

            return Json(new[] { leavetype }.ToDataSourceResult(request, ModelState));
        }
    }
}