using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCSystemDemo.Models.ViewModels
{
    public class AccountRegisterViewModel
    {
        [DisplayName("Identity Number")]
        public string IdentityNumber { get; set; }
        [DisplayName("UserName")]
        public string UserName { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
        [DisplayName("Phone Number")]
        public string Phone { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Status")]
        public int Status { get; set; }
    }
}