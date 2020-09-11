using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspCoreTraining.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAdmin { get; set; }
        [Required]
        public string Job { get; set; }

        //M:M
        public ICollection<LectureStudent> LectureStudents { get; set; }
    }
}
