using System.Collections.Generic;

namespace CRM.Models
{
    public static class Repository
    {
        private static List<Volunteer> volunteers = new List<Volunteer>();

        public static IEnumerable<Volunteer> Volunteers
        {
            get
            {
                return volunteers;
            }
        }

        public static void AddVolunteer(Volunteer volunteer)
        {
           volunteers.Add(volunteer);
        }
    }
}