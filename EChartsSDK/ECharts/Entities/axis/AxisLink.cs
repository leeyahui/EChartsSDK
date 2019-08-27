using System.Linq;

namespace ECharts.Entities.axis
{
    public class AxisLink
    {
        public object xAxisIndex { get; set; }

        public object yAxisIndex { get; set; }

        public string xAxisName { get; set; }

        public string yAxisName { get; set; }

        public string angleAxis { get; set; }

        public AxisLink AngleAxis(string angleAxis)
        {
            this.angleAxis = angleAxis;
            return this;
        }


        public AxisLink XAxisIndex(params double[] values)
        {
            xAxisIndex = values.ToList();
            return this;
        }

        public AxisLink YAxisIndex(params double[] values)
        {
            yAxisIndex = values.ToList();
            return this;
        }


        public AxisLink XAxisIndex(string xAxisName)
        {
            this.xAxisName = xAxisName;
            return this;
        }


        public AxisLink YAxisIndex(string yAxisName)
        {
            this.yAxisName = yAxisName;
            return this;
        }
    }
}