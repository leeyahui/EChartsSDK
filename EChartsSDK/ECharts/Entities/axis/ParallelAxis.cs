﻿namespace ECharts.Entities.axis
{
    public class ParallelAxis : ChartAxis<ParallelAxis>
    {
        public int? dim { get; set; }

        public object name { get; set; }

        public ParallelAxis Dim(int dim)
        {
            this.dim = dim;
            return this;
        }

        public ParallelAxis Name(string Name)
        {
            name = name;
            return this;
        }
    }
}