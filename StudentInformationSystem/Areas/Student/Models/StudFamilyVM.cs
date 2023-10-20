using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace StudentInformationSystem.Areas.Student.Models
{
    public class StudFamilyVM : StudentFamily, IModel<StudentFamily, StudFamilyVM>
    {
        public StudFamilyVM()
        {
            mappings = new ObjMappings<StudentFamily, StudFamilyVM>()
            {
                {x => x.Parent.Title, x => x.Title },
                {x => x.Parent.FullName, x => x.FullName },
                {x => x.Parent.Occupation, x => x.Occupation },
                {x => x.Parent.WorkingAddress, x => x.WorkingAddress },
                {x => x.Parent.OfficePhoneNo, x => x.OfficePhoneNo },
                {x => x.Parent.MobileNo, x => x.MobileNo },
                {x => x.Parent.HomePhoneNo, x => x.HomePhoneNo },
                {x => x.Parent.Email, x => x.Email },
                {x => x.Parent.NicNo, x => x.NicNo },
                {x => x.IsEmergencyContact ? "Yes" : "No", x => x.IsEmergencyContactDisplay }
            };
        }

        public StudFamilyVM(StudentFamily obj) : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<StudentFamily, StudFamilyVM> mappings { get; set; }

        public TitleStaff Title { get; set; }
        public string FullName { get; set; }
        public string Occupation { get; set; }
        public string WorkingAddress { get; set; }
        public string OfficePhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string HomePhoneNo { get; set; }
        public string Email { get; set; }
        public string NicNo { get; set; }
        public string IsEmergencyContactDisplay { get; set; }
    }
}