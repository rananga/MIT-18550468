using System;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class BaseModel
    {
        public BaseModel()
        {
        }
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
