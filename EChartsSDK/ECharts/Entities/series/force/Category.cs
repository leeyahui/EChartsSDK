using ECharts.Entities.style;

namespace ECharts.Entities.series
{
    public class Category
    {
        public Category(string name)
        {
            this.name = name;
        }

        public string name { get; set; }

        public string symbol { get; set; }

        public object symbolSize { get; set; }

        public ItemStyle itemStyle { get; set; }

        public Category SymbolSize(object symbolSize)
        {
            this.symbolSize = symbolSize;
            return this;
        }

        public Category Symbol(string symbol)
        {
            this.symbol = symbol;
            return this;
        }

        public Category Name(string name)
        {
            this.name = name;
            return this;
        }


        public ItemStyle ItemStyle()
        {
            if (itemStyle == null)
                itemStyle = new ItemStyle();
            return itemStyle;
        }
    }
}