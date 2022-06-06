using System.ComponentModel.DataAnnotations;

namespace E_Learning.Models
{
    public class Course
    {
        [Key]
        public Guid ID { get; set; }
        public string Course_Name { get; set; }
        public string Course_Date { get; set; }
    }
}
