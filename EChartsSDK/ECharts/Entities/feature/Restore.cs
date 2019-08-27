namespace ECharts.Entities.feature
{
    public class Restore
    {
        public bool? show { get; set; }

        public string title { get; set; }

        public Restore Show(bool show)
        {
            this.show = show;
            return this;
        }

        public Restore Title(string title)
        {
            this.title = title;
            return this;
        }
    }
}