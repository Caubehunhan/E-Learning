using System.ComponentModel.DataAnnotations;

namespace E_Learning.Models
{
    public class Permission
    {
        [Key]
        public Guid ID { get; set; }
        public string Permission_name { get; set; }
    }
}
