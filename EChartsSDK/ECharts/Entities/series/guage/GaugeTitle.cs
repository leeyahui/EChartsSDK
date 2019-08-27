using System.Collections.Generic;
using ECharts.Entities.style;

namespace ECharts.Entities
{
    public class GaugeTitle
    {
        public bool? show { get; set; }

        public IList<string> offsetCenter { get; set; }

        public TextStyle textStyle { get; set; }


        public TextStyle TextStyle()
        {
            if (textStyle == null)
                textStyle = new TextStyle();
            return textStyle;
        }

        public GaugeTitle OffsetCenter(IList<string> offsetCenter)
        {
            this.offsetCenter = offsetCenter;
            return this;
        }

        public GaugeTitle Show(bool show)
        {
            this.show = show;
            return this;
        }
    }
}