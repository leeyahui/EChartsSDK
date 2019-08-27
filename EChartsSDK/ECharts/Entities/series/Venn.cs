namespace ECharts.Entities.series
{
    public class Venn : ChartSeries<Venn>
    {
        public Venn()
        {
            type = ChartType.venn;
        }

        public Venn(string name) : this()
        {
            this.name = name;
        }
    }
}