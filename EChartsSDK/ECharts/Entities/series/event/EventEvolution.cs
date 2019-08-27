using System;

namespace ECharts.Entities.series
{
    public class EventEvolution
    {
        public DateTime? time { get; set; }

        public int? value { get; set; }

        public EventDetail detail { get; set; }

        public EventEvolution Time(DateTime time)
        {
            this.time = time;
            return this;
        }

        public EventEvolution Value(int value)
        {
            this.value = value;
            return this;
        }

        public EventDetail Detail()
        {
            if (detail == null)
                detail = new EventDetail();
            return detail;
        }
    }
}