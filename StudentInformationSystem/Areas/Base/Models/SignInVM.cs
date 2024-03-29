﻿using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.ComponentModel;
using System.Web;

namespace StudentInformationSystem.Areas.Base.Models
{
    public class SignInVM : User, IModel<User, SignInVM>
    {
        public SignInVM()
        {
            mappings = new ObjMappings<User, SignInVM>();
            mappings.Add(x => x.Password, x => x.Password.Encrypt());
            mappings.Add(x => x.Password.Decrypt(), x => x.Password);
        }
        public SignInVM(User obj)
            : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<User, SignInVM> mappings { get; set; }

        public string UserEmail { get; set; }
        public string AccessToken { get; set; }
        public bool RememberMe { get; set; }
        [DisplayName("New Password")]
        public string NewPassword { get; set; }
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}