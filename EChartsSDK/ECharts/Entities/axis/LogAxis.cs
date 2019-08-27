namespace ECharts.Entities.axis
{
    public class LogAxis : ChartAxis<LogAxis>
    {
        public LogAxis()
        {
            type = AxisType.log;
        }

        public bool? logPositive { get; set; }

        public int? logLabelBase { get; set; }


        public LogAxis LogLabelBase(int logLabelBase)
        {
            this.logLabelBase = logLabelBase;
            return this;
        }

        public LogAxis LogPositive(bool logPositive)
        {
            this.logPositive = logPositive;
            return this;
        }
    }
}