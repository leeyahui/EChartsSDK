using System.Collections.Generic;
using System.Linq;

namespace ECharts.Entities.axis
{
    public class ValueAxis : ChartAxis<ValueAxis>
    {
        public ValueAxis()
        {
            type = AxisType.value;
        }

        public object boundaryGap { get; set; }

        public ValueAxis BoundaryGap(IList<double> boundaryGap)
        {
            this.boundaryGap = boundaryGap;
            return this;
        }

        public ValueAxis BoundaryGap(params double[] values)
        {
            if (boundaryGap == null) boundaryGap = new List<double>();
            boundaryGap = values.ToList();
            return this;
        }

        public ValueAxis BoundaryGap(params object[] values)
        {
            if (boundaryGap == null) boundaryGap = new List<object>();
            boundaryGap = values.ToList();
            return this;
        }

        /// <param name="boundaryGap"></param>
        public ValueAxis BoundaryGap(object boundaryGap)
        {
            this.boundaryGap = boundaryGap;
            return this;
        }
    }
}