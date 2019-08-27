using ECharts.Entities.data;

namespace ECharts.Entities.series
{
    public class MarkData : BasicData<MarkData>
    {
        public MarkData()
        {
        }

        public MarkData(string name, MarkType type) : this()
        {
            this.name = name;
            this.type = type;
        }

        public MarkData(MarkType type) : this()
        {
            this.type = type;
        }

        public MarkData(string name) : this()
        {
            this.name = name;
        }
    }
}