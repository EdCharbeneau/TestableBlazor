using System;
using System.ComponentModel.Design;

namespace TestableBlazor.Client
{
    public class UserFormViewModel
    {
        public DateTime BirthDate { get; set; } = new DateTime(1980, 1, 1);
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SelectedRegion { get; set; }
        public string[] Regions { get; set; }
        public string SelectedTeam { get; set; }
        public string[] Teams { get; set; }
    }

}
