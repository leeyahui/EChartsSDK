using ECharts.Entities.style;

namespace ECharts.Entities
{
    /// <summary>
    ///     �����ļ�
    /// </summary>
    public class Title : Basic<Title>
    {
        #region properties       

        public string id { get; set; }
        public object text { get; set; }

        public string link { get; set; }

        public TargetType? target { get; set; }

        public string subtext { get; set; }

        public string sublink { get; set; }

        public TargetType? subtarget { get; set; }

        public HorizontalType? textAlign { get; set; }

        public HorizontalType? align { get; set; }

        public int? itemGap { get; set; }

        public TextStyle textStyle { get; set; }

        public TextStyle subtextStyle { get; set; }

        #endregion

        #region method

        public Title Id(string id)
        {
            this.id = id;
            return this;
        }

        public TextStyle TextStyle()
        {
            if (textStyle == null)
                textStyle = new TextStyle();
            return textStyle;
        }

        public TextStyle SubtextStyle()
        {
            if (subtextStyle == null)
                subtextStyle = new TextStyle();
            return subtextStyle;
        }

        public Title ItemGap(int itemGap)
        {
            this.itemGap = itemGap;
            return this;
        }

        public Title BorderWidth(int borderWidth)
        {
            this.borderWidth = borderWidth;
            return this;
        }

        public Title TextAlign(HorizontalType textAlign)
        {
            this.textAlign = textAlign;
            return this;
        }

        public Title Align(HorizontalType align)
        {
            this.align = align;
            return this;
        }


        public Title Subtarget(TargetType subtarget)
        {
            this.subtarget = subtarget;
            return this;
        }

        public Title Sublink(string sublink)
        {
            this.sublink = sublink;
            return this;
        }

        public Title Subtext(string subtext)
        {
            this.subtext = subtext;
            return this;
        }

        public Title Target(TargetType target)
        {
            this.target = target;
            return this;
        }

        public Title Link(string link)
        {
            this.link = link;
            return this;
        }

        public Title Text(string text)
        {
            this.text = text;
            return this;
        }

        public Title Text(object text)
        {
            this.text = text;
            return this;
        }

        public Title SubText(string subtext)
        {
            this.subtext = subtext;
            return this;
        }

        #endregion
    }
}