using HRM.Common;
using HRM.Data.DbContext;
using HRM.Data.Entities.User;
using HRM.Interface;
using System.Data.Entity;
using System.Linq;


namespace HRM.Services
{
    public class UserProfileService : IUserProfileService
    {
        HRMDbContext _dbcontext;
        public UserProfileService(HRMDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
      
        public Contact GetContactById()
        {
            Contact contact = _dbcontext.Contact.Where(cnt => cnt.UserId == AppSession.UserId).FirstOrDefault();
            return contact;
        }
    }
}
