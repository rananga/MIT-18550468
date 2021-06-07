﻿using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Nalanda.SMS.Areas.Student.Models
{
    public class StudentExtraActivityAcheivementVM : StudentExtraActivityAcheivement, IModel<StudentExtraActivityAcheivement, StudentExtraActivityAcheivementVM>
    {
        public StudentExtraActivityAcheivementVM()
        {
            mappings = new ObjMappings<StudentExtraActivityAcheivement, StudentExtraActivityAcheivementVM>(); ;

            mappings.Add(x => x.Acheivement.Name, x => x.AcheivementName);
            mappings.Add(x => x.Acheivement.Description, x => x.AcheivementDescription);
        }

        public StudentExtraActivityAcheivementVM(StudentExtraActivityAcheivement obj) : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<StudentExtraActivityAcheivement, StudentExtraActivityAcheivementVM> mappings { get; set; }

        [DisplayName("Acheivement Name")]
        public string AcheivementName { get; set; }
        [DisplayName("Acheivement Description")]
        public string AcheivementDescription { get; set; }
    }
}