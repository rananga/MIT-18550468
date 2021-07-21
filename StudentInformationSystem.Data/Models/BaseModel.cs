using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInformationSystem.Data.Models
{
    public partial class BaseModel
    {
        public BaseModel()
        {
        }
        [Column("Id", Order = 0)]
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        [Column("CreatedDate", TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        [Column("ModifiedDate", TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }
        [NotMapped]
        public string JsonData { get; set; }
    }
}
