using System.Text.Json.Serialization;

namespace DbGame
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string SystemRequirements { get; set; }
        [JsonIgnore]
        public List<User> Users { get; set; } = new List<User>();
        public List<Accounting> Accounting { get; set; } 
    }
}