using PraiseAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.DTOs
{
    public class CharacterDto
    {
        public CharacterDto() { }
        public int OwningUserId { get; set; }
        public string Name { get; set; }
        public string OwningUserName { get; set; }
        public int Level { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastConnectionDate { get; set; }
        public bool IsPlaying { get; set; }
        public bool IsCurrentCharacter { get; set; }
        public bool IsNpc { get; set; }
        public int FactionId { get; set; }
        public string CurrentGameZone { get; set; }
        public float CurrentExp { get; set; }
        public float LevelUpExp { get; set; }
        public int CharSex { get; set; }
        public int Strenght { get; set; }
        public int Constitution { get; set; }
        public int Dextrity { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int Luck { get; set; }
        public float MaxHealth { get; set; }
        public float MaxStamina { get; set; }


        public CharacterDto(DataRow row)
        {
            Name = row.IsNull(nameof(Name)) ? "" : Convert.ToString(row[nameof(Name)]);
            OwningUserId = row.IsNull(nameof(OwningUserId)) ? 0 : Convert.ToInt32(row[nameof(OwningUserId)]);
            OwningUserName = row.IsNull(nameof(OwningUserName)) ? "" : Convert.ToString(row[nameof(OwningUserName)]);
            CreationDate = row.IsNull(nameof(CreationDate)) ? DateTime.Now : Convert.ToDateTime(row[nameof(CreationDate)]);
            LastConnectionDate = row.IsNull(nameof(LastConnectionDate)) ? null : Convert.ToDateTime(row[nameof(LastConnectionDate)]);
            IsPlaying = row.IsNull(nameof(IsPlaying)) ? false : Convert.ToBoolean(row[nameof(IsPlaying)]);
            IsNpc = row.IsNull(nameof(IsNpc)) ? false : Convert.ToBoolean(row[nameof(IsNpc)]);
            IsCurrentCharacter = row.IsNull(nameof(IsCurrentCharacter)) ? false : Convert.ToBoolean(row[nameof(IsCurrentCharacter)]);
            FactionId = row.IsNull(nameof(FactionId)) ? 0 : Convert.ToInt32(row[nameof(FactionId)]);
            CharSex = row.IsNull(nameof(CharSex)) ? 0 : Convert.ToInt32(row[nameof(CharSex)]);
            CurrentGameZone = row.IsNull(nameof(CurrentGameZone)) ? "" : Convert.ToString(row[nameof(CurrentGameZone)]);
            Level = row.IsNull(nameof(Level)) ? 0 : Convert.ToInt32(row[nameof(Level)]);
            Strenght = row.IsNull(nameof(Strenght)) ? 0 : Convert.ToInt32(row[nameof(Strenght)]);
            Constitution = row.IsNull(nameof(Constitution)) ? 0 : Convert.ToInt32(row[nameof(Constitution)]);
            Dextrity = row.IsNull(nameof(Dextrity)) ? 0 : Convert.ToInt32(row[nameof(Dextrity)]);
            Intelligence = row.IsNull(nameof(Intelligence)) ? 0 : Convert.ToInt32(row[nameof(Intelligence)]);
            Wisdom = row.IsNull(nameof(Wisdom)) ? 0 : Convert.ToInt32(row[nameof(Wisdom)]);
            Charisma = row.IsNull(nameof(Charisma)) ? 0 : Convert.ToInt32(row[nameof(Charisma)]);
            Luck = row.IsNull(nameof(Luck)) ? 0 : Convert.ToInt32(row[nameof(Luck)]);
            MaxHealth = row.IsNull(nameof(MaxHealth)) ? 0.0f : (float)Convert.ToDouble(row[nameof(MaxHealth)]);
            MaxStamina = row.IsNull(nameof(MaxStamina)) ? 0.0f : (float)Convert.ToDouble(row[nameof(MaxStamina)]);
            CurrentExp = row.IsNull(nameof(CurrentExp)) ? 0.0f : (float)Convert.ToDouble(row[nameof(CurrentExp)]);
            LevelUpExp = row.IsNull(nameof(LevelUpExp)) ? 0.0f : (float)Convert.ToDouble(row[nameof(LevelUpExp)]);

        }
    }
}
