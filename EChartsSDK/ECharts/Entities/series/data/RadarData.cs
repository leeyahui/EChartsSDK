using System.Linq;
using ECharts.Entities.style;

namespace ECharts.Entities.series.data
{
    public class RadarData
    {
        public RadarData(string name)
        {
            this.name = name;
        }

        public RadarData(object value, string name)
        {
            this.value = value;
            this.name = name;
        }

        public RadarData(object value, string name, ItemStyle itemStyle) : this(value, name)
        {
            this.itemStyle = itemStyle;
        }

        public object value { get; set; }
        public string name { get; set; }

        public object symbol { get; set; }

        public object symbolSize { get; set; }


        public ItemStyle itemStyle { get; set; }

        public ItemStyle ItemStyle()
        {
            if (itemStyle == null) itemStyle = new ItemStyle();
            return itemStyle;
        }

        public RadarData Value(params object[] values)
        {
            if (values == null)
                return this;
            value = values.ToList();
            return this;
        }

        public RadarData Symbol(string symbol)
        {
            this.symbol = symbol;
            return this;
        }

        public RadarData SymbolSize(object symbolSize)
        {
            this.symbolSize = symbolSize;
            return this;
        }
    }
}