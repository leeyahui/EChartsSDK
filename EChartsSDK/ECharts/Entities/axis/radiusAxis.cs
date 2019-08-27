namespace ECharts.Entities.axis
{
    public class RadiusAxis : ChartAxis<RadiusAxis>
    {
        public RadiusAxis(AxisType type)
        {
            this.type = type;
        }

        public int? polarIndex { get; set; }


        public RadiusAxis PolarIndex(int polarIndex)
        {
            this.polarIndex = polarIndex;
            return this;
        }
    }
}