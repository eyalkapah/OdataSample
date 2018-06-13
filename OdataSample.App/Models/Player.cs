using System;

namespace OdataSample.App.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime BirthDate { get; set; }

        // Navigation properties
        public Team Team { get; set; }
    }
}