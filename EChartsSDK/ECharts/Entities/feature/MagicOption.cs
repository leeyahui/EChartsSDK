using ECharts.Entities.series;

namespace ECharts.Entities.feature
{
    public class MagicOption
    {
        public Line line { get; set; }

        public Bar bar { get; set; }

        //public Tiled tiled { get; set; }

        public Force force { get; set; }

        public Chord chord { get; set; }

        public Pie pie { get; set; }

        public Funnel funnel { get; set; }

        public Chord Chord()
        {
            if (chord == null)
                chord = new Chord();
            return chord;
        }

        public Pie Pie()
        {
            if (pie == null)
                pie = new Pie();
            return pie;
        }

        public Funnel Funnel()
        {
            if (funnel == null)
                funnel = new Funnel();
            return funnel;
        }


        public Line Line()
        {
            if (line == null)
                line = new Line();
            return line;
        }


        public Bar Bar()
        {
            if (bar == null)
                bar = new Bar();
            return bar;
        }

        public Force Force()
        {
            if (force == null)
                force = new Force();
            return force;
        }
    }
}