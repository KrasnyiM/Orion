using System.Text.Json.Serialization;

namespace DbGame
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public List<Game> Games { get; set; } = new List<Game>();
        [JsonIgnore]
        public List<Accounting> Accounting { get; set; } 
    }
}
