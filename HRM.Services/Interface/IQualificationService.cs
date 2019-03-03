using HRM.Data.Entities.General;
using HRM.Data.Entities.Qualification;
using HRM.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Interface
{
   public interface IQualificationService
    {
        IQueryable<SkillTitle> Read();
        IQueryable<Education> ReadPayGrade();
        IQueryable<Certification> ReadCertification();
        IQueryable<Language> ReadLanguage();
        SkillTitle GetSkillTitleById(int Id);
        Education GetEducationById(int Id);
        Certification GetCertificationById(int Id);
        Language GetLanguageById(int Id);
    }
}
