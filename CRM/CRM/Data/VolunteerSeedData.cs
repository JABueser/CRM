using CRM.Models;
using CRM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Data
{
    public class VolunteerSeedData : IVolunteerService
    {
        public Task<Volunteer[]> GetIncompleteVolunteersAsync()
        {
            var item1 = new Volunteer
            {
                volunteerID = 1,
                firstName = "John",
                lastName = "Amiel",
                email = "johnamiel@email.com",
                interest = "Foodline",
                hours = 0
            };
            return Task.FromResult(new[] { item1 });
        }
    }
}
