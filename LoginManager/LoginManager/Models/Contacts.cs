using System.ComponentModel.DataAnnotations;
using System.Globalization;
namespace LoginManager.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}