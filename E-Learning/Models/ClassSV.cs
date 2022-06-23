using System.ComponentModel.DataAnnotations;

namespace E_Learning.Models
{
    public class ClassSV
    {
        [Key]
        public string ID { get; set; }
        public Class Class { get; set; }
        public User SV { get; set; }
    }
}
