using ECharts.Entities.style;

namespace ECharts.Entities.series.data
{
    public class PieData<T>
    {
        public PieData(T value, string name)
        {
            this.value = value;
            this.name = name;
        }

        public PieData(T value, string name, ItemStyle itemStyle) : this(value, name)
        {
            this.itemStyle = itemStyle;
        }

        public T value { get; set; }
        public string name { get; set; }

        public ItemStyle itemStyle { get; set; }

        public ItemStyle ItemStyle()
        {
            if (itemStyle == null) itemStyle = new ItemStyle();
            return itemStyle;
        }
    }
}