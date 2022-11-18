// Stopped at 6.3 min. 8:00
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PokeCenter.API.Base.Entities
{
    public class Team
    {
        // Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]                           //generate a ney identity key when generating an entry
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }
        public ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();    //initialise the property with an empty list

        public Team(string name)                                                    //this ctur forces every team to have at least a Name entry
        {
            Name = name;
        }
    }
}