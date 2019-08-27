namespace ECharts.Entities.axis
{
    public class CategoryAxis : ChartAxis<CategoryAxis>
    {
        public CategoryAxis()
        {
            type = AxisType.category;
        }

        public bool? boundaryGap { get; set; }

        public CategoryAxis BoundaryGap(bool boundaryGap)
        {
            this.boundaryGap = boundaryGap;
            return this;
        }
    }
}