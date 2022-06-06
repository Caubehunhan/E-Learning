using System.ComponentModel.DataAnnotations;

namespace E_Learning.Models
{
    public class CategoryTest
    {
        [Key]
        public Guid ID { get; set; }
        public string TheLoaiThi { get; set; }
    }
}
