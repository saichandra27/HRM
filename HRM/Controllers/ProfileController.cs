using HRM.Data.Entities.User;
using HRM.Interface;
using HRM.Services;
using System.Web.Mvc;

namespace HRM.Controllers
{
    [Authorize(Roles = "SystemAdmin,Accounts")]
    public class ProfileController : Controller
    {
        private IUserProfileService ups;
        DbContextHelper _dbcontexthelper;

        public ProfileController(IUserProfileService upsservice)
        {
            _dbcontexthelper = new DbContextHelper();
            ups = upsservice;
        }

        // GET: UserInformation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageUsers()
        {
            return View();
        }

        public PartialViewResult Contact()
        {
            Contact cnt = ups.GetContactById();
            return PartialView("Contact", cnt);
        }

        public PartialViewResult Dependents()
        {
            // Dependent dpnt = ups.();
            return PartialView("Dependents");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveContactInfo(Contact Contact)
        {
            _dbcontexthelper.AttachToContext(Contact);
            return View("Index", Contact);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveDependentInfo(Dependent Dependent)
        {
            _dbcontexthelper.AttachToContext(Dependent);
            return View("Index", Dependent);
        }
    }
}

