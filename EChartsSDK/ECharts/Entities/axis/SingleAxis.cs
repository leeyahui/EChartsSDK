namespace ECharts.Entities.axis
{
    public class SingleAxis : ChartAxis<SingleAxis>
    {
        public SingleAxis()
        {
        }

        public SingleAxis(AxisType type)
        {
            this.type = type;
        }
    }
}