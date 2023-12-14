using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.Entities
{
    public class PraiseCharacter : Entity
    {
        public PraiseCharacter() { User = null; CharStats = new List<CharStats>(); }

        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? LastConnectionDate { get; set; }
        public bool IsPlaying { get; set; }
        public bool IsNpc { get; set; }
        public string CurrentGameZone { get; set; }
        public int FactionId { get; set; }
        public bool IsCurrentCharacter { get; set; }
        public int CharSex { get; set; }
        public int UserId { get; set; }
        public PraiseUser User { get; set; }
        public List<CharStats> CharStats { get; set; } 
        
        public PraiseCharacter(DataRow row)
        {
            Name = row.IsNull(nameof(Name)) ? "" : Convert.ToString(row[nameof(Name)]);
            CreationDate = row.IsNull(nameof(CreationDate)) ? DateTime.Now : Convert.ToDateTime(row[nameof(CreationDate)]);
            ModificationDate = row.IsNull(nameof(ModificationDate)) ? DateTime.Now : Convert.ToDateTime(row[nameof(ModificationDate)]);
            DeleteDate = row.IsNull(nameof(DeleteDate)) ? null : Convert.ToDateTime(row[nameof(DeleteDate)]);
            LastConnectionDate = row.IsNull(nameof(LastConnectionDate)) ? null : Convert.ToDateTime(row[nameof(LastConnectionDate)]);
            IsPlaying = row.IsNull(nameof(IsPlaying)) ? false : Convert.ToBoolean(row[nameof(IsPlaying)]);
            FactionId = row.IsNull(nameof(FactionId)) ? 0 : Convert.ToInt32(row[nameof(FactionId)]);
            IsCurrentCharacter = row.IsNull(nameof(IsCurrentCharacter)) ? false : Convert.ToBoolean(row[nameof(IsCurrentCharacter)]);
            CharSex = row.IsNull(nameof(CharSex)) ? 0 : Convert.ToInt32(row[nameof(CharSex)]);
            UserId = row.IsNull(nameof(UserId)) ? 0 : Convert.ToInt32(row[nameof(UserId)]);

            User = new PraiseUser();
            CharStats = new List<CharStats>();
        }
    }
}
