using ECharts.Entities.axis;
using ECharts.Entities.style;

namespace ECharts.Entities
{
    public class Calendar : Basic<Calendar>
    {
        public object cellSize { get; set; }

        public object range { get; set; }

        public SplitLine splitLine { get; set; }

        public ItemStyle itemStyle { get; set; }

        public CalendarLabel dayLabel { get; set; }

        public CalendarLabel monthLabel { get; set; }

        public CalendarLabel yearLabel { get; set; }

        public Calendar Range(object range)
        {
            this.range = range;
            return this;
        }

        public Calendar CellSize(object cellSize)
        {
            this.cellSize = cellSize;
            return this;
        }

        public ItemStyle ItemStyle()
        {
            if (itemStyle == null)
                itemStyle = new ItemStyle();
            return itemStyle;
        }

        public CalendarLabel DayLabel()
        {
            if (dayLabel == null)
                dayLabel = new CalendarLabel();
            return dayLabel;
        }

        public CalendarLabel MonthLabel()
        {
            if (monthLabel == null)
                monthLabel = new CalendarLabel();
            return monthLabel;
        }

        public CalendarLabel YearLabel()
        {
            if (yearLabel == null)
                yearLabel = new CalendarLabel();
            return yearLabel;
        }
    }
}