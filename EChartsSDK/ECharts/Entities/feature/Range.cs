﻿namespace ECharts.Entities.feature
{
    public class Range
    {
        public int? start { get; set; }

        public int? end { get; set; }

        public Range End(int end)
        {
            this.end = end;
            return this;
        }

        public Range Start(int start)
        {
            this.start = start;
            return this;
        }
    }
}