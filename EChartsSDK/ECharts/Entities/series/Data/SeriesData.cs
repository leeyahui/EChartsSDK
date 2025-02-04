﻿using System.Collections.Generic;
using System.Linq;
using ECharts.Entities.style;

namespace ECharts.Entities.series.data
{
    public class SeriesData<T>
    {
        public T value { get; set; }

        public IList<SeriesData<T>> children { get; set; }

        public string name { get; set; }

        public ToolTip tooltip { get; set; }

        public ItemStyle itemStyle { get; set; }

        public object symbol { get; set; }

        public int? symbolRotate { get; set; }

        public object symbolSize { get; set; }

        public StyleLabel label { get; set; }

        public StyleLabel Label()
        {
            if (label == null)
                label = new StyleLabel();
            return label;
        }

        public SeriesData<T> SymbolRotate(int symbolRotate)
        {
            this.symbolRotate = symbolRotate;
            return this;
        }

        public SeriesData<T> Symbol(SymbolType symbol)
        {
            this.symbol = symbol;
            return this;
        }

        public SeriesData<T> Symbol(string symbol)
        {
            this.symbol = symbol;
            return this;
        }

        public SeriesData<T> SymbolSize(object symbolSize)
        {
            this.symbolSize = symbolSize;
            return this;
        }

        public SeriesData<T> Children(params SeriesData<T>[] values)
        {
            if (values == null) return this;
            children = values.ToList();
            return this;
        }


        public ToolTip ToolTip()
        {
            if (tooltip == null)
                tooltip = new ToolTip();
            return tooltip;
        }

        public ItemStyle ItemStyle()
        {
            if (itemStyle == null)
                itemStyle = new ItemStyle();
            return itemStyle;
        }

        #region constructor

        public SeriesData(T value) : this(value, null, null)
        {
        }

        public SeriesData(T value, string name) : this(value)
        {
            this.name = name;
        }

        public SeriesData(T value, ToolTip tooltip) : this(value, tooltip, null)
        {
        }

        public SeriesData(T value, ItemStyle itemStyle) : this(value, null, itemStyle)
        {
        }

        public SeriesData(T value, ToolTip tooltip, ItemStyle itemStyle)
        {
            this.value = value;
            this.tooltip = tooltip;
            this.itemStyle = itemStyle;
        }

        #endregion
    }
}