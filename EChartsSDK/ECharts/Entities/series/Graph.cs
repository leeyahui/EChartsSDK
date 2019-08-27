namespace ECharts.Entities.series
{
    public class Graph : ChartSeries<Graph>
    {
        public Graph()
        {
            type = ChartType.graph;
        }

        public string layout { get; set; }

        public object links { get; set; }

        public object categories { get; set; }

        public graph.Force force { get; set; }

        public Graph Categories(object categories)
        {
            this.categories = categories;
            return this;
        }

        public Graph Links(object links)
        {
            this.links = links;
            return this;
        }

        public Graph Layout(string layout)
        {
            this.layout = layout;
            return this;
        }

        public graph.Force Force()
        {
            if (force == null)
                force = new graph.Force();
            return force;
        }
    }
}