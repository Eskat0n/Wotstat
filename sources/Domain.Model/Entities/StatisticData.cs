using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Entities
{
    class StatisticData
    {
        public virtual int Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual int User { get; set; }
        public virtual int HitsPercents { get; set; }
        public virtual int BattleAvgXp { get; set; }
        public virtual int WinsPercents { get; set; }
        public virtual int Battles { get; set; }
        public virtual int DamageDealt { get; set; }
        public virtual int Frags { get; set; }
        public virtual int MaxXp { get; set; }

    }
}
                      