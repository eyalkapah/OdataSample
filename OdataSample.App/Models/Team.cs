using System.Collections.Generic;

namespace OdataSample.App.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int GroupId { get; set; }

        public string Name { get; set; }
        public int Rank { get; set; }

        // Navigation properties
        public Group Group { get; set; }
        public ICollection<Player> Players { get; set; }
    }

}