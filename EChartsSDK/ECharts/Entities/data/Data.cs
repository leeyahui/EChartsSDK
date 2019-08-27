namespace ECharts.Entities.data
{
    public class Data : BasicData<Data>
    {
        public string extra { get; set; }

        public Data Extra(string extra)
        {
            this.extra = extra;
            return this;
        }
    }
}