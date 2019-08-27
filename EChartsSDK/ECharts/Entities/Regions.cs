///////////////////////////////////////////////////////////
//  Regions.cs
//  Implementation of the Class Regions
//  Generated by Enterprise Architect
//  Created on:      16-2��-2017 22:58:29
//  Original author: Doku
///////////////////////////////////////////////////////////

using ECharts.Entities.style;

namespace ECharts.Entities
{
    public class Regions
    {
        public string name { get; set; }

        public bool selected { get; set; }

        public ItemStyle itemStyle { get; set; }

        public ItemStyle label { get; set; }

        public ItemStyle ItemStyle()
        {
            if (itemStyle == null)
                itemStyle = new ItemStyle();
            return itemStyle;
        }

        public ItemStyle Label()
        {
            if (label == null)
                label = new ItemStyle();
            return label;
        }
    } //end Regions
} //end namespace Entities