namespace ECharts.Entities.series
{
    public class TreeMap : ChartSeries<TreeMap>
    {
        public TreeMap()
        {
            type = ChartType.treemap;
        }

        public TreeMap(string name) : this()
        {
            this.name = name;
        }

        public object center { get; set; }

        public object size { get; set; }

        public string root { get; set; }

        public object levels { get; set; }

        public TreeMap Levels(object levels)
        {
            this.levels = levels;
            return this;
        }

        public TreeMap Center(object center)
        {
            this.center = center;
            return this;
        }

        public TreeMap Size(object size)
        {
            this.size = size;
            return this;
        }

        public TreeMap Root(string root)
        {
            this.root = root;
            return this;
        }
    }
}