using System.Collections.Generic;
using ECharts.Entities.style;

namespace ECharts.Entities
{
    public class TreeData
    {
        public string name { get; set; }

        public string symbol { get; set; }

        public object symbolSize { get; set; }

        public int? value { get; set; }

        public IList<TreeData> children { get; set; }

        public ItemStyle itemStyle { get; set; }

        public ItemStyle ItemStyle()
        {
            if (itemStyle == null)
                itemStyle = new ItemStyle();
            return itemStyle;
        }

        public TreeData Value(int value)
        {
            this.value = value;
            return this;
        }

        public TreeData SymbolSize(string symbolSize)
        {
            this.symbolSize = symbolSize;
            return this;
        }

        public TreeData Symbol(string symbol)
        {
            this.symbol = symbol;
            return this;
        }

        public TreeData Name(string name)
        {
            this.name = name;
            return this;
        }
    }
}