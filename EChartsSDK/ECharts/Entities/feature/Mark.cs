﻿using ECharts.Entities.style;

namespace ECharts.Entities.feature
{
    public class Mark
    {
        public bool? show { get; set; }

        public MarkTitle title { get; set; }

        public LineStyle lineStyle { get; set; }

        public Mark Show(bool show)
        {
            this.show = show;
            return this;
        }

        public MarkTitle Title()
        {
            if (title == null)
                title = new MarkTitle();
            return title;
        }

        public LineStyle LineStyle()
        {
            if (lineStyle == null)
                lineStyle = lineStyle;
            return lineStyle;
        }
    }
}