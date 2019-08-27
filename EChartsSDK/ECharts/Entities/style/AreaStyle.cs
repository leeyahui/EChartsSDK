namespace ECharts.Entities.style
{
    public class AreaStyle : Style<AreaStyle>
    {
        public object color { get; set; }

        public AreaStyleType? type { get; set; }

        public AreaStyle Color(object color)
        {
            this.color = color;
            return this;
        }

        public AreaStyle Type(AreaStyleType type)
        {
            this.type = type;
            return this;
        }
    }
}