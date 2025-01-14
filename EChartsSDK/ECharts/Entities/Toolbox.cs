﻿using System.Collections.Generic;
using ECharts.Entities.feature;
using ECharts.Entities.style;

namespace ECharts.Entities
{
    public class ToolBox : Basic<ToolBox>
    {
        public OrientType? orient { get; set; }

        public int? itemGap { get; set; }

        public int? itemSize { get; set; }

        public IList<string> color { get; set; }

        public string disableColor { get; set; }

        public string effectiveColor { get; set; }

        public bool? showTitle { get; set; }

        public TextStyle textStyle { get; set; }

        public Feature feature { get; set; }

        public ItemStyle iconStyle { get; set; }


        public ToolBox ShowTitle(bool showTitle)
        {
            this.showTitle = showTitle;
            return this;
        }

        public ToolBox EffectiveColor(string effectiveColor)
        {
            this.effectiveColor = effectiveColor;
            return this;
        }


        public ToolBox DisableColor(string disableColor)
        {
            this.disableColor = disableColor;
            return this;
        }

        public ToolBox ItemSize(int itemSize)
        {
            this.itemSize = itemSize;
            return this;
        }

        public ToolBox ItemGap(int itemGap)
        {
            this.itemGap = itemGap;
            return this;
        }

        public ToolBox Orient(OrientType orient)
        {
            this.orient = orient;
            return this;
        }


        public Feature Feature()
        {
            if (feature == null)
                feature = new Feature();
            return feature;
        }

        public ToolBox SetFeature(Feature feature)
        {
            this.feature = feature;
            return this;
        }

        public TextStyle TextStyle()
        {
            if (textStyle == null)
                textStyle = new TextStyle();
            return textStyle;
        }

        public ItemStyle IconStyle()
        {
            if (iconStyle == null) iconStyle = new ItemStyle();
            return iconStyle;
        }
    }
}