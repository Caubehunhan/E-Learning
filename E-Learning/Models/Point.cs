using System.ComponentModel.DataAnnotations;

namespace E_Learning.Models
{
    public class Point
    {
        [Key]
        public Guid ID { get; set; }
        public User SV { get; set; }  
        public DateTime NgayKT { get; set; }
        public Class Class { get; set; }    
        public Subjects subjects { get; set; }
        public CategoryTest categoryTest { get; set; }
        public string FilePath { get; set; }
        public string Diem { get; set; }
        public string comment { get; set; }

    }
}
