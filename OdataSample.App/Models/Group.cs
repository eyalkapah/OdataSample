using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OdataSample.App.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Required]
        public char Name { get; set; }

        // Navigation properties
        public ICollection<Team> Teams { get; set; }
    }
}