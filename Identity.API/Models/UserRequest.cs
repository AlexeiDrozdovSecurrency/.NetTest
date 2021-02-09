using System.ComponentModel.DataAnnotations;

namespace TestWeb.API.Models
{
    public class UserRequest
    {
        [Required]
        public string FirstName { get; set; }
     
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Country { get; set; }
        
        [Required]
        public string City { get; set; }
        
        public string State { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }
        
        public string PostalCode { get; set; }

        public string FlatNumber { get; set; }
    }
}