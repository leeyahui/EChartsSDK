namespace ECharts.Entities
{
    public class GradientColorData
    {
        public GradientColorData(double offset, string color)
        {
            this.offset = offset;
            this.color = color;
        }

        public double? offset { get; set; }

        public string color { get; set; }
    }
}