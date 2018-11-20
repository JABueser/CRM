using CRM.Data;
using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Services
{
    public class SqlVolunteerData : IVolunteerData
    {
        private ApplicationDbContext _context;

        public SqlVolunteerData(ApplicationDbContext context)
        {
            _context = context;
        }

        public Volunteer Get(int id)
        {
            return _context.Volunteers.FirstOrDefault(v => v.volunteerID == id);
        }
        public IEnumerable<Volunteer> GetAll()
        {
            return _context.Volunteers.OrderBy(v => v.lastName);
        }
    }
}
