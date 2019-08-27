namespace ECharts.Entities.feature
{
    public class Feature
    {
        public Mark mark { get; set; }

        public DataZoom dataZoom { get; set; }

        public DataView dataView { get; set; }

        public MagicType magicType { get; set; }

        public Restore restore { get; set; }

        public FeatureImage saveAsImage { get; set; }


        public FeatureBrush brush { get; set; }

        public MagicType MagicType()
        {
            if (magicType == null)
                magicType = new MagicType();
            return magicType;
        }

        public FeatureBrush Brush()
        {
            if (brush == null)
                brush = new FeatureBrush();
            return brush;
        }


        public Mark Mark()
        {
            if (mark == null)
                mark = new Mark();
            return mark;
        }

        public DataZoom DataZoom()
        {
            if (dataZoom == null)
                dataZoom = new DataZoom();
            return dataZoom;
        }

        public DataView DataView()
        {
            if (dataView == null)
                dataView = new DataView();
            return dataView;
        }


        public Restore Restore()
        {
            if (restore == null)
                restore = new Restore();
            return restore;
        }

        public FeatureImage SaveAsImage()
        {
            if (saveAsImage == null)
                saveAsImage = new FeatureImage();
            return saveAsImage;
        }
    }
}