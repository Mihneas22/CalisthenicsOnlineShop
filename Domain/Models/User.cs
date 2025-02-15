using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
            
        public string? username { get; set; }

        public string? email { get; set; }

        public string? password { get; set; }

        public string? city { get; set; }

        public string? country { get; set; }

        public int? points { get; set; }

        public List<string>? itemsBoughtHistory { get; set; }

        public List<string>? shoppingCart { get; set; }

        public DateTime? createdAccount { get; set; }
    }
}
