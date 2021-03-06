﻿namespace Messages
{
    using System;

    public class PlayerInfo
    {
        public DateTime Time { get; set; }
        public int PlayerId { get; set; }
        public double HitsPercents { get; set; }
        public double BattleAvgXp { get; set; }
        public int Draws { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Battles { get; set; }
        public int DamageDealt { get; set; }
        public int Frags { get; set; }
        public int MaxXp { get; set; }
    }
}
