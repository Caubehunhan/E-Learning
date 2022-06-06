using System.ComponentModel.DataAnnotations;

namespace E_Learning.Models
{
    public class Test
    {
        [Key]
        public Guid ID { get; set; }
        public Class Class { get; set; }
        public DateTime NgayKT { get; set; }
        public Subjects subjects { get; set; }
        public string NoiDung { get; set; }
        public CategoryTest TheLoaiThi { get; set; }
        public long Time { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public string Status { get; set; }
    }
}
