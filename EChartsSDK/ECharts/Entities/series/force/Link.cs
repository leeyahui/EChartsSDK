using ECharts.Entities.style;

namespace ECharts.Entities.series
{
    public class Link
    {
        public Link()
        {
        }

        public Link(string name)
        {
            this.name = name;
        }

        public string name { get; set; }

        public object source { get; set; }

        public object target { get; set; }

        public double? weight { get; set; }

        public ItemStyle itemStyle { get; set; }


        public Link Name(string name)
        {
            this.name = name;
            return this;
        }


        public Link Source(object source)
        {
            this.source = source;
            return this;
        }

        public Link Target(object target)
        {
            this.target = target;
            return this;
        }

        public Link Weight(double weight)
        {
            this.weight = weight;
            return this;
        }

        public ItemStyle ItemStyle()
        {
            if (itemStyle == null)
                itemStyle = new ItemStyle();
            return itemStyle;
        }
    }
}