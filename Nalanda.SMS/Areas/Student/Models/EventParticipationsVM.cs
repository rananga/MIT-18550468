using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Nalanda.SMS.Areas.Student.Models
{
    public class EventParticipationsVM : IModel<EventParticipation, EventParticipationsVM>
    {
        public EventParticipationsVM()
        {

            mappings = new ObjMappings<EventParticipation, EventParticipationsVM>();
            mappings.Add(x => x.Student.Title + ". " + x.Student.Initials.Trim() + " " + x.Student.Lname, x => x.StudentName);
            mappings.Add(x => x.Teacher.Title + ". " + x.Teacher.Initials.Trim() + " " + x.Teacher.Lname, x => x.TeacherName);


        }

        public EventParticipationsVM(EventParticipation obj) : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<EventParticipation, EventParticipationsVM> mappings { get; set; }

        public int EPID { get; set; }
        [DisplayName("Student"), Required]
        public int StudID { get; set; }
        [DisplayName("Date"), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime Date { get; set; }
        [DisplayName("Event Description"), Required]
        [DataType(DataType.MultilineText)]
        public string EventDesc { get; set; }
        [DisplayName("Is Prize Winner"), Required]
        public bool IsWinner { get; set; }
        [DisplayName("Winner Details"), Required]
        [DataType(DataType.MultilineText)]
        public string WinningDetails { get; set; }
        [DisplayName("Teacher in-Charge"), Required]
        public int TeacherInCharge { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }
        [DisplayName("Student")]
        public string StudentName { get; set; }
        [DisplayName("Teacher in-Charge")]
        public string  TeacherName { get; set; }

        public virtual Nalanda.SMS.Data.Models.Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}