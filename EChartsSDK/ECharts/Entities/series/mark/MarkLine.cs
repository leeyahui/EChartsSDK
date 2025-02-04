﻿using ECharts.Entities.style;

namespace ECharts.Entities.series
{
    public class MarkLine : AbstractData<MarkPoint>
    {
        public bool? clickable { get; set; }

        public object symbol { get; set; }

        public object symbolSize { get; set; }

        public object symbolRotate { get; set; }

        public bool? large { get; set; }

        public bool? smooth { get; set; }

        public double? smoothness { get; set; }

        public int? precision { get; set; }

        public Bound bounding { get; set; }

        public Effect effect { get; set; }

        public ItemStyle itemStyle { get; set; }

        public ItemStyle label { get; set; }

        public EntityStyle<LineStyle> lineStyle { get; set; }

        public ToolTip toolTip { get; set; }

        public MarkLine Precision(int precision)
        {
            this.precision = precision;
            return this;
        }

        public MarkLine Ssmooth(double smoothness)
        {
            this.smoothness = smoothness;
            return this;
        }

        public MarkLine Smooth(bool smooth)
        {
            this.smooth = smooth;
            return this;
        }

        public MarkLine Large(bool large)
        {
            this.large = large;
            return this;
        }

        public MarkLine SymbolRotate(object symbolRotate)
        {
            this.symbolRotate = symbolRotate;
            return this;
        }

        public MarkLine Symbol(object symbol)
        {
            this.symbol = symbol;
            return this;
        }

        public MarkLine SymbolSize(object symbolSize)
        {
            this.symbolSize = symbolSize;
            return this;
        }


        public Bound Bound()
        {
            if (bounding == null)
                bounding = new Bound();
            return bounding;
        }

        public MarkLine SetItemStyle(ItemStyle itemStyle)
        {
            this.itemStyle = itemStyle;
            return this;
        }

        public ItemStyle ItemStyle()
        {
            if (itemStyle == null)
                itemStyle = new ItemStyle();
            return itemStyle;
        }

        public Effect Effect()
        {
            if (effect == null)
                effect = new Effect();
            return effect;
        }

        public ItemStyle Label()
        {
            if (label == null)
                label = new ItemStyle();
            return label;
        }

        public EntityStyle<LineStyle> LineStyle()
        {
            if (lineStyle == null)
                lineStyle = new EntityStyle<LineStyle>();
            return lineStyle;
        }

        public ToolTip ToolTip()
        {
            if (toolTip == null)
                toolTip = new ToolTip();
            return toolTip;
        }
    }
}