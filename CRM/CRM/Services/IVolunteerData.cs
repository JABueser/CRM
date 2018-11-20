using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Services
{
    public interface IVolunteerData
    {
        IEnumerable<Volunteer> GetAll();
        Volunteer Get(int id);
        //Volunteer Add(Volunteer volunteer);
        //void Save(Volunteer volunteer);
        //Volunteer Delete(int Id);
    }
}
