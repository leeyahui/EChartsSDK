﻿using ECharts.Entities.style;

namespace ECharts.Entities.axis
{
    public class AxisLine
    {
        public bool? show { get; set; }

        public bool? onZero { get; set; }

        public LineStyle lineStyle { get; set; }


        public LineStyle LineStyle()
        {
            if (lineStyle == null)
                lineStyle = new LineStyle();
            return lineStyle;
        }

        public AxisLine OnZero(bool onZero)
        {
            this.onZero = onZero;
            return this;
        }

        public AxisLine Show(bool show)
        {
            this.show = show;
            return this;
        }
    }
}