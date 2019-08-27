using ECharts.Entities.style;

namespace ECharts.Entities.axis
{
    public class AxisPointer : Basic<AxisPointer>
    {
        public bool? show { get; set; }

        public AxisPointType? type { get; set; }

        public bool? snap { get; set; }

        public AxisLink link { get; set; }

        public AxisLabel label { get; set; }

        public LineStyle lineStyle { get; set; }

        public LineStyle crossStyle { get; set; }

        public AreaStyle shadowStyle { get; set; }

        public AxisPointer Show(bool show)
        {
            this.show = show;
            return this;
        }


        public AxisLink Link()
        {
            if (link == null)
                link = new AxisLink();
            return link;
        }

        public AxisPointer Type(AxisPointType type)
        {
            this.type = type;
            return this;
        }

        public AxisPointer Snap(bool snap)
        {
            this.snap = snap;
            return this;
        }

        public AxisLabel Label()
        {
            if (label == null) label = new AxisLabel();
            return label;
        }

        public LineStyle LineStyle()
        {
            if (lineStyle == null) lineStyle = new LineStyle();
            return lineStyle;
        }

        public LineStyle CrossStyle()
        {
            if (crossStyle == null) crossStyle = new LineStyle();
            return crossStyle;
        }


        public AreaStyle ShadowStyle()
        {
            if (shadowStyle == null) shadowStyle = new AreaStyle();
            return shadowStyle;
        }
    }
}