using ECharts.Entities.axis;

namespace ECharts.Entities
{
    public class IndicatorData
    {
        public IndicatorData()
        {
        }

        public IndicatorData(string text)
        {
            this.text = text;
        }

        public string text { get; set; }

        public int? min { get; set; }

        public int? max { get; set; }

        public AxisLabel axisLabel { get; set; }

        public AxisLabel AxisLabel()
        {
            if (axisLabel == null)
                axisLabel = new AxisLabel();
            return axisLabel;
        }

        public IndicatorData Text(string text)
        {
            this.text = text;
            return this;
        }

        public IndicatorData Min(int min)
        {
            this.min = min;
            return this;
        }

        public IndicatorData Max(int max)
        {
            this.max = max;
            return this;
        }
    }
}