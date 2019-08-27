namespace ECharts.Entities.series
{
    public class Scatter : Rectangular<Scatter>
    {
        public Scatter()
        {
            type = ChartType.scatter;
        }

        public Scatter(string name) : this()
        {
            this.name = name;
        }

        public bool? large { get; set; }

        public int? largeThreshold { get; set; }

        public bool? hoverAnimation { get; set; }

        public Scatter LargeThreshold(int largeThreshold)
        {
            this.largeThreshold = largeThreshold;
            return this;
        }


        public Scatter HoverAnimation(bool hoverAnimation)
        {
            this.hoverAnimation = hoverAnimation;
            return this;
        }

        public Scatter Large(bool large)
        {
            this.large = large;
            return this;
        }
    }
}