namespace ECharts.Entities.series
{
    public class LocationData
    {
        public LocationData()
        {
        }

        public LocationData(object x, object y)
        {
            this.x = x;
            this.y = y;
        }

        public object x { get; set; }
        public object y { get; set; }
    }
}