using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System;
using System.ComponentModel;
using System.Web;

namespace StudentInformationSystem.Areas.Online.Models
{
    public class OCR_ClassRoomVM : OCR_ClassRoom, IModel<OCR_ClassRoom, OCR_ClassRoomVM>
    {
        public OCR_ClassRoomVM()
        {
            mappings = new ObjMappings<OCR_ClassRoom, OCR_ClassRoomVM>();

            mappings.Add(x => x.PhysicalClassRoom.GradeClass.Code, x => x.ClassCode);
        }

        public OCR_ClassRoomVM(OCR_ClassRoom obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<OCR_ClassRoom, OCR_ClassRoomVM> mappings { get; set; }

        [DisplayName("Physical Class")]
        public string ClassCode { get; set; }
    }
}