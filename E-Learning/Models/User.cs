using System.ComponentModel.DataAnnotations;

namespace E_Learning.Models
{
    public class User
    {
        [Key]
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone  { get; set; }
        public Permission Permission { get; set; }
    }
}
