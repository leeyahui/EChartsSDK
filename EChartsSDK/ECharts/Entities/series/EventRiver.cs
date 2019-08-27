namespace ECharts.Entities.series
{
    public class EventRiver : ChartSeries<EventRiver>
    {
        public EventRiver()
        {
            type = ChartType.eventRiver;
        }

        public EventRiver(string name) : this()
        {
            this.name = name;
        }

        public int? xAxisIndex { get; set; }

        public int? weight { get; set; }

        public bool? legendHoverLink { get; set; }

        public EventRiver LegendHoverLink(bool legendHoverLink)
        {
            this.legendHoverLink = legendHoverLink;
            return this;
        }

        public EventRiver XAxisIndex(int xAxisIndex)
        {
            this.xAxisIndex = xAxisIndex;
            return this;
        }

        public EventRiver Weight(int weight)
        {
            this.weight = weight;
            return this;
        }
    }
}