using ECharts.Entities.style;

namespace ECharts.Entities
{
    public class VisualMap
    {
        /// <summary>
        ///     类型
        /// </summary>
        public VisualMapType type { get; set; }

        /// <summary>
        ///     最小值
        /// </summary>
        public int min { get; set; }

        /// <summary>
        ///     最大值
        /// </summary>
        public int max { get; set; }

        /// <summary>
        ///     是否启用值域漫游
        /// </summary>
        public bool calculable { get; set; }

        /// <summary>
        ///     拖拽时，是否实时更新
        /// </summary>
        public bool realtime { get; set; }

        /// <summary>
        ///     是否反转
        /// </summary>
        public bool inverse { get; set; }

        /// <summary>
        ///     数据展示的小数精度，默认为0，无小数点
        /// </summary>
        public int precision { get; set; }

        /// <summary>
        ///     图形的宽度，即长条的宽度
        /// </summary>
        public int itemWidth { get; set; }

        /// <summary>
        ///     图形的高度，即长条的高度
        /// </summary>
        public int itemHeight { get; set; }

        public int itemSymbol { get; set; }

        /// <summary>
        ///     指定组件中手柄和文字的摆放关系
        /// </summary>
        public int align { get; set; }

        /// <summary>
        ///     handle 指『拖拽手柄』。handlePosition 指定了手柄的位置
        /// </summary>
        public int handlePosition { get; set; }

        /// <summary>
        ///     指定用数据的『哪个维度』，映射到视觉元素上
        /// </summary>
        public object dimension { get; set; }

        /// <summary>
        ///     指定取哪个系列的数据，即哪个系列的 series.data
        /// </summary>
        public int seriesIndex { get; set; }

        /// <summary>
        ///     定义 在选中范围中 的视觉元素
        /// </summary>
        public VisualMapType inRange { get; set; }

        /// <summary>
        ///     定义 在选中范围外 的视觉元素
        /// </summary>
        public VisualMapType outOfRange { get; set; }

        /// <summary>
        ///     水平（'horizontal'）或者竖直（'vertical'）
        /// </summary>
        public Orient orient { get; set; }

        /// <summary>
        ///     标签的格式化工具
        /// </summary>
        public string formatter { get; set; }

        /// <summary>
        ///     对于连续型数据，自动平均切分成几段
        /// </summary>
        public int splitNumber { get; set; }

        public SelectedMode selectedMode { get; set; }
        public TextStyle textStyle { get; set; }
        public object[] color { get; set; }
        public object[] text { get; set; }
        public object[] textGap { get; set; }
        public object[] pieces { get; set; }
        public object[] categories { get; set; }
    }
}