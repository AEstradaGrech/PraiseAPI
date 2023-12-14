using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.Entities
{
    public class CharStats : Entity
    {
        public CharStats() { }

        public int Level { get; set; }
        public float LevelUpExp { get; set; }
        public float CharExp { get; set; }
        public int Strenght { get; set; }
        public int Constitution { get; set; }
        public int Dextrity { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int Luck { get; set; }
        public float MaxHealth { get; set; }
        public float MaxStamina { get; set; }

        public DateTime? LevelUpDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public int CharacterId { get; set; }
        public PraiseCharacter Character { get; set; }
    }
}
