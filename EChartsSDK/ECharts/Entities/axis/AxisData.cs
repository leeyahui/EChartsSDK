using ECharts.Entities.style;

namespace ECharts.Entities.axis
{
    public class AxisData<T>
    {
        public T value { get; set; }

        public TextStyle textStyle { get; set; }

        public TextStyle TextStyle()
        {
            if (textStyle == null)
                textStyle = new TextStyle();
            return textStyle;
        }
    }
}