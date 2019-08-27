namespace ECharts.Entities.style
{
    public class IconStyle
    {
        public string name { get; set; }

        public TextStyle textStyle { get; set; }

        public string icon { get; set; }

        public TextStyle TextStyle()
        {
            if (textStyle == null)
                textStyle = new TextStyle();
            return textStyle;
        }

        public IconStyle Name(string name)
        {
            this.name = name;
            return this;
        }

        public IconStyle Icon(string icon)
        {
            this.icon = icon;
            return this;
        }
    }
}