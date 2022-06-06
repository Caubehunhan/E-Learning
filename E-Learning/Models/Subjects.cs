using System.ComponentModel.DataAnnotations;

namespace E_Learning.Models
{
    public class Subjects
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
