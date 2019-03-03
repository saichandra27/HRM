using HRM.Common;
using HRM.Data.DbContext;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM.Data.Entities.User
{
    [TrackChanges]
    public class Dependent : ISoftDeleteable, IRecordInfo
    {
        private string GetUserId()
        {
            return AppSession.UserId;
        }

        HRMDbContext _dbcontext;

        public Dependent()
        {
        }

        public Dependent(HRMDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public int ID { get; set; }
        public HRMUser UserId { get; set; }
        public string Name { get; set; }
        public Relation Relationship { get; set; }
        public string OtherRelationship { get; set; }
        public string NationalIdentityNumber { get; set; }
        public DateTime DOB { get; set; }
        public string OtherInformation { get; set; }
        [SkipTracking]
        public bool IsDeleted { get; set; }
        public string Createdby
        {
            get { return hrmuser; }
            set { hrmuser = GetUserId(); }
        }
        public string Modifiedby
        {
            get { return hrmuser; }
            set { hrmuser = GetUserId(); }
        }
        public DateTime? Created
        {
            get { return datetime; }
            set { datetime = DateTime.Now; }
        }
        public DateTime? Modified
        {
            get { return datetime; }
            set { datetime = DateTime.Now; }
        }

        private string hrmuser;
        private DateTime datetime;
      
        public string Attachments { get; set; }
    }

    public enum Relation
    {
        Father = 1,
        Mother = 2,
        Wife = 3,
        Son = 4,
        Daughter = 5,
        Sister = 6,
        Brother = 7,
        FatherInlaw = 8,
        MotherInlaw = 9,
        GrandMother = 10,
        GrandFather = 11,
        Others = 12
    }
}
