using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace TestableBlazor.Client
{
    public class UserFormViewModel
    {
        [Required]
        public DateTime BirthDate { get; set; } = new DateTime(1980, 1, 1);
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string SelectedRegion { get; set; } = string.Empty;
        [Required]
        public string[] Regions { get; set; } = [];
        [Required]
        public string SelectedTeam { get; set; } = string.Empty;
        [Required]
        public string[] Teams { get; set; } = [];
    }

}