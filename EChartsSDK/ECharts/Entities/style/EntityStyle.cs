namespace ECharts.Entities.style
{
    public class EntityStyle<T> where T : class, new()
    {
        public T normal { get; set; }

        public T emphasis { get; set; }

        public T Normal()
        {
            if (normal == null) normal = new T();
            return normal;
        }

        public T Emphasis()
        {
            if (emphasis == null) emphasis = new T();
            return emphasis;
        }
    }
}