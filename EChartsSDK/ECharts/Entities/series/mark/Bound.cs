namespace ECharts.Entities.series
{
    public class Bound
    {
        public bool? enable { get; set; }

        public int? maxTuringAngle { get; set; }


        public Bound Enable(bool enable)
        {
            this.enable = enable;
            return this;
        }

        public Bound MaxTuringAngle(int maxTuringAngle)
        {
            this.maxTuringAngle = maxTuringAngle;
            return this;
        }
    }
}