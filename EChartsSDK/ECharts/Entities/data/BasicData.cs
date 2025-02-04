﻿using System.Collections.Generic;
using System.Linq;
using ECharts.Entities.style;

namespace ECharts.Entities.data
{
    public abstract class BasicData<T> where T : class
    {
        public string name { get; set; }

        public string text { get; set; }

        public object value { get; set; }

        public object x { get; set; }

        public object y { get; set; }

        public object xAxis { get; set; }

        public object yAxis { get; set; }

        public MarkType? type { get; set; }

        public object symbol { get; set; }

        public object symbolSize { get; set; }

        public ItemStyle itemStyle { get; set; }

        public EntityStyle<LineLabelStyle> label { get; set; }

        public int? valueIndex { get; set; }

        public IList<object> coord { get; set; }


        public T SymbolSize(object symbolSize)
        {
            this.symbolSize = symbolSize;
            return this as T;
        }

        public T X(object x)
        {
            this.x = x;
            return this as T;
        }

        public T XAxis(object xAxis)
        {
            this.xAxis = xAxis;
            return this as T;
        }

        public T Y(object y)
        {
            this.y = y;
            return this as T;
        }

        public T YAxis(object yAxis)
        {
            this.yAxis = yAxis;
            return this as T;
        }


        public T Value(object value)
        {
            this.value = value;
            return this as T;
        }

        public T ValueIndex(int valueIndex)
        {
            this.valueIndex = valueIndex;
            return this as T;
        }

        public ItemStyle ItemStyle()
        {
            if (itemStyle == null)
                itemStyle = new ItemStyle();
            return itemStyle;
        }

        public EntityStyle<LineLabelStyle> Label()
        {
            if (label == null)
                label = new EntityStyle<LineLabelStyle>();
            return label;
        }

        public T Symbol(object symbol)
        {
            this.symbol = symbol;
            return this as T;
        }

        public T Text()
        {
            name = name;
            return this as T;
        }

        public T Type(MarkType type)
        {
            this.type = type;
            return this as T;
        }

        public T Coord(params double[] values)
        {
            if (coord == null)
                coord = new List<object>();
            values.ToList().ForEach(v => coord.Add(v));
            return this as T;
        }
    }
}