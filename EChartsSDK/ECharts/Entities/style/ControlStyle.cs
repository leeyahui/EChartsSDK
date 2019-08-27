namespace ECharts.Entities.style
{
    public class ControlStyle
    {
        public bool? showNextBtn { get; set; }

        public bool? showPrevBtn { get; set; }


        public int? itemSize { get; set; }

        public int? itemGap { get; set; }

        public Normal normal { get; set; }

        public Emphasis empasis { get; set; }

        public Emphasis Emphasis()
        {
            if (empasis == null)
                empasis = new Emphasis();
            return empasis;
        }

        public Normal Normal()
        {
            if (normal == null)
                normal = new Normal();
            return normal;
        }

        public ControlStyle ItemGap(int itemGap)
        {
            this.itemGap = itemGap;
            return this;
        }

        public ControlStyle ShowNextBtn(bool showNextBtn)
        {
            this.showNextBtn = showNextBtn;
            return this;
        }

        public ControlStyle ShowPrevBtn(bool showPrevBtn)
        {
            this.showPrevBtn = showPrevBtn;
            return this;
        }
    }
}