using System.ComponentModel.DataAnnotations;

namespace E_Learning.Models
{
    public class ClassSubjects
    {
        [Key]
        public Guid ID { get; set; }
        public Class Class { get; set; }
        public DateTime ThoiGian { get; set; }
        public Subjects subjects { get; set; }
        public long SoTiet { get; set; }
    }
}
