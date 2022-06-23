using System.ComponentModel.DataAnnotations;

namespace E_Learning.Models
{
    public class Class
    {
        [Key]
        public string ID { get; set; }
        public string Class_Name { get; set; }
        public string Description { get; set; }
        public User Teacher { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public Course Course { get; set; }
    }
}
