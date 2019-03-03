using HRM.Data.DbContext;
using HRM.Data.Entities;
using HRM.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        // GET: Role
        HRMDbContext _dbcontext;
        private HRMUserManager _userManager;

        public RoleController(HRMDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public RoleController()
        {
        }
        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(_dbcontext.Roles.AsEnumerable());
        }
        /// <summary>
        /// Create  a New role
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }
        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            _dbcontext.Roles.Add(Role);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AssignRoleToUser(string userid, string[] roles)
        {
            UserManager.AddToRoles(userid, roles);
            return RedirectToAction("Index");
        }

        public HRMUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<HRMUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public JsonResult GetUserslstJsonResult()
        {
            try
            {
                var lstusers = _dbcontext.Users.Select(usr => new SelectListItem() { Value = usr.Id, Text = usr.UserName }).ToList();
                return Json(lstusers, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

    }
}