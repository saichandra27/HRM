using HRM.Data.Entities.Organistion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Interface
{
    public interface IOrganisationService
    {
        IQueryable<Organisation> Read();
        IQueryable<Location> ReadPayGrade();
        Organisation GetOrganisationById(int Id);
        Location GetLocationById(int Id);
    }
}
