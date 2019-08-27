using ECharts.Entities.style;

namespace ECharts.Entities.series.mark
{
    public class MarkArea : AbstractData<MarkArea>
    {
        public ItemStyle itemStyle { get; set; }

        public ItemStyle ItemStyle()
        {
            if (itemStyle == null)
                itemStyle = new ItemStyle();
            return itemStyle;
        }
    }
}