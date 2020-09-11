using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspCoreTraining.Models
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // One to Many 
        public int CourseId { get; set; }
        public Course Course { get; set; }

        // Many to many 
        public ICollection<LectureStudent> LectureStudents { get; set; }
    }

    public class LectureStudent
    {
        public int Id { get; set; }
        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
