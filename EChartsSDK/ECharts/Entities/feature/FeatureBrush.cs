using System.Collections.Generic;
using System.Linq;

namespace ECharts.Entities.feature
{
    public class FeatureBrush
    {
        public IList<BrushType> type { get; set; }

        public BrushIcon icon { get; set; }

        public BrushTitle title { get; set; }

        public FeatureBrush Type(params BrushType[] values)
        {
            type = values.ToList();
            return this;
        }

        public BrushIcon Icon()
        {
            if (icon == null)
                icon = new BrushIcon();
            return icon;
        }

        public BrushTitle Title()
        {
            if (title == null)
                title = new BrushTitle();
            return title;
        }
    }

    public class BrushIcon
    {
        public string rect { get; set; }

        public string polygon { get; set; }

        public string lineX { get; set; }

        public string lineY { get; set; }

        public string keep { get; set; }

        public string clear { get; set; }
    }

    public class BrushTitle
    {
        public string rect { get; set; }

        public string polygon { get; set; }

        public string lineX { get; set; }

        public string lineY { get; set; }

        public string keep { get; set; }

        public string clear { get; set; }
    }
}