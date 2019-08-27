namespace ECharts.Entities.style
{
    public class ItemStyle
    {
        public Normal normal { get; set; }

        public Emphasis emphasis { get; set; }

        public Normal Normal()
        {
            if (normal == null) normal = new Normal();
            return normal;
        }

        public Emphasis Emphasis()
        {
            if (emphasis == null) emphasis = new Emphasis();
            return emphasis;
        }
    }
}