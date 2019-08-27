namespace ECharts.Entities.series
{
    public class Bar : Rectangular<Bar>
    {
        public Bar()
        {
            type = ChartType.bar;
        }

        public Bar(string name) : this()
        {
            this.name = name;
        }

        public object barGap { get; set; }

        public object barCategoryGap { get; set; }

        public int? barMinHeight { get; set; }

        public int? barWidth { get; set; }

        public int? barHeight { get; set; }

        public int? barMaxWidth { get; set; }

        public Bar BarMaxWidth(int barMaxWidth)
        {
            this.barMaxWidth = barMaxWidth;
            return this;
        }

        public Bar BarWidth(int barWidth)
        {
            this.barWidth = barWidth;
            return this;
        }

        public Bar BarHeight(int barHeight)
        {
            this.barHeight = barHeight;
            return this;
        }

        public Bar BarCategoryGap(object barCategoryGap)
        {
            this.barCategoryGap = barCategoryGap;
            return this;
        }


        public Bar BarGap(object barGap)
        {
            this.barGap = barGap;
            return this;
        }
    }
}