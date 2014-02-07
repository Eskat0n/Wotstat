namespace Wotstat.Application.Statistics.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Domain.Model.Entities;

    public class StatisticFieldItemArray
    {
        public StatisticFieldItemArray()
        {
            Names = new List<string>();
            Functions = new List<Func<StatisticalData, double>>();
        }

        public StatisticFieldItemArray Add(string name, Func<StatisticalData, double> func)
        {
            Names.Add(name);
            Functions.Add(func);
            return this;
        }

        public List<string> Names { get; private set; }
        public List<Func<StatisticalData, double>> Functions { get; private set; }
    }
}