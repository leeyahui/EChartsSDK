using System.Collections.Generic;
using System.Linq;

namespace ECharts.Entities.feature
{
    public class MagicType
    {
        public bool? show { get; set; }

        public MagicTitle title { get; set; }

        public MagicOption option { get; set; }

        public IList<object> type { get; set; }

        public MagicType Show(bool show)
        {
            this.show = show;
            return this;
        }

        public MagicType SetType(IList<object> type)
        {
            this.type = type;
            return this;
        }

        public MagicType Type(params string[] values)
        {
            if (values == null)
                return this;
            if (type == null)
                type = new List<object>();
            values.ToList().ForEach(v => type.Add(v));
            return this;
        }

        public MagicTitle Title()
        {
            if (title == null)
                title = new MagicTitle();
            return title;
        }

        public MagicOption Option()
        {
            if (option == null)
                option = new MagicOption();
            return option;
        }
    }
}