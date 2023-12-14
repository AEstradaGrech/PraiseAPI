using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.DTOs
{
    public class CharStatsDto
    {
        public int Level { get; set; }
        public float Exp { get; set; }
        public int Strenght { get; set; }
        public int Constitution { get; set; }
        public int Dextrity { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Luck { get; set; }
        public float MaxHealth { get; set; }
        public float MaxStamina { get; set; }
        public DateTime? LevelUpDate { get; set; }
    }
}
