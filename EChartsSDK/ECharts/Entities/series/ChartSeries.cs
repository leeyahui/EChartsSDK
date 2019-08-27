using System.Linq;

namespace ECharts.Entities.series
{
    public class ChartSeries<T> : Series, IData<T> where T : class
    {
        public object data { get; set; }

        public T Data(params object[] values)
        {
            if (values == null)
                return default;
            data = values.ToList();
            return this as T;
        }

        public T SetData(object data)
        {
            this.data = data;
            return this as T;
        }
    }
}