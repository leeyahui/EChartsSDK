using ECharts.Entities.style;

namespace ECharts.Entities.axis
{
    public class SplitArea
    {
        public bool? show { get; set; }

        public bool? onGap { get; set; }

        public AreaStyle areaStyle { get; set; }


        public SplitArea OnGap(bool onGap)
        {
            this.onGap = onGap;
            return this;
        }

        public AreaStyle AreaStyle()
        {
            if (areaStyle == null)
                areaStyle = new AreaStyle();
            return areaStyle;
        }

        public SplitArea Show(bool show)
        {
            this.show = show;
            return this;
        }
    }
}