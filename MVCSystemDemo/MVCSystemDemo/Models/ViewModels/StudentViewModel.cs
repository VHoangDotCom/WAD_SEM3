using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSystemDemo.Models.ViewModels
{
    public class StudentViewModel
    {
        //ID
        [Display(Name = "Student ID")]
        public int ID { get; set; }

        //LastName
        [DisplayName("Last name")]
        [Required(ErrorMessage = "Please enter last name !")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The length is between 2 and 20 characters ! !")]
        public string LastName { get; set; }

        //Fisrt name
        [DisplayName("First name")]
        [Required(ErrorMessage = "Please enter first name !")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The length is between 2 and 20 characters ! !")]
        public string FirstMidName { get; set; }

        //Enrollment date
        [DisplayName("Enrollment date")]
        [Required(ErrorMessage = "Please enter Enrollment date !")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public StudentViewModel()
        {

        }
        public StudentViewModel(Student st)
        {
            this.LastName = st.LastName;
            this.FirstMidName = st.FirstMidName;
            this.EnrollmentDate = st.EnrollmentDate;
        }
    }
}