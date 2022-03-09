using MVCSystemDemo.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSystemDemo.Models
{
    public class Student
    {
        //ID
        public int ID { get; set; }

        //LastName
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }

        //Fisrt name
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string FirstMidName { get; set; }

        //Enrollment date
        [Required]
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public Student()
        {

        }

        public Student(StudentViewModel stview)
        {
            this.LastName = stview.LastName;
            this.FirstMidName = stview.FirstMidName;
            this.EnrollmentDate = stview.EnrollmentDate;
           
        }
    }
}