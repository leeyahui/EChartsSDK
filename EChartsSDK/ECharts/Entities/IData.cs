namespace ECharts.Entities
{
    public interface IData<T>
    {
        T Data(params object[] values);
    }
}