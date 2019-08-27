﻿using System.Collections.Generic;
using System.Linq;

namespace ECharts.Entities.series
{
    public class EventData
    {
        public EventData()
        {
        }

        public EventData(string name)
        {
            this.name = name;
        }

        public string name { get; set; }

        public int? weight { get; set; }

        public IList<EventEvolution> evolution { get; set; }

        public EventData Name(string name)
        {
            this.name = name;
            return this;
        }

        public EventData Weight(int weight)
        {
            this.weight = weight;
            return this;
        }

        public EventData Evolution(params EventEvolution[] values)
        {
            if (values == null)
                return this;
            evolution = values.ToList();
            return this;
        }
    }
}