using AutoMapper;
using Nalanda.SMS.Data.Models;
using System.ComponentModel;

namespace Nalanda.SMS.Models
{
    public class SignInVM : User
    {                
        public bool RememberMe { get; set; }
        [DisplayName("New Password")]
        public string NewPassword { get; set; }
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }

    public class SignInProfile : Profile
    {
        public SignInProfile()
        {
            CreateMap<User, SignInVM>().ReverseMap();
        }
    }
}