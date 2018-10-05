using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Services
{
    public interface IVolunteerService
    {
        Task<Volunteer[]> GetIncompleteVolunteersAsync();

    }
}
