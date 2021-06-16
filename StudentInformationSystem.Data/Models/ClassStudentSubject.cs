namespace StudentInformationSystem.Data.Models
{
    public partial class ClassStudentSubject : BaseModel
    {
        public int ClassStudentId { get; set; }
        public int SubjectId { get; set; }

        public virtual ClassStudent ClassStudent { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
