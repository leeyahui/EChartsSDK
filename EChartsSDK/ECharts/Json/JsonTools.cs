using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ECharts
{
    /// <summary>
    ///     Json Tools
    /// </summary>
    public class JsonTools
    {
        /// <summary>
        ///     Generate Json string from the object
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Json String</returns>
        public static string ObjectToJson(object obj)
        {
            //System.Runtime.Serialization.Json.DataContractJsonSerializer;

            var serializer = new DataContractJsonSerializer(obj.GetType());
            var stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            var dataBytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(dataBytes, 0, (int) stream.Length);
            var dataString = Encoding.UTF8.GetString(dataBytes);
            return dataString;
        }

        /// <summary>
        ///     Generate a object from Json string
        /// </summary>
        /// <param name="jsonString">Json string</param>
        /// <param name="obj">Object</param>
        /// <returns>Object</returns>
        public static object JsonToObject(string jsonString, object obj)
        {
            var serializer = new DataContractJsonSerializer(obj.GetType());
            var mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            obj = serializer.ReadObject(mStream);
            return obj;
        }

        /// <summary>
        ///     Generate a object from Json string
        /// </summary>
        /// <param name="jsonString">Json string</param>
        /// <param name="obj">Object</param>
        /// <returns>Object</returns>
        public static T JsonToObject<T>(string jsonString)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                return (T) serializer.ReadObject(mStream);
            }
        }

        /// <summary>
        ///     序列化数据为Json数据格式.
        /// </summary>
        /// <param name="value">被序列化的对象</param>
        /// <returns></returns>
        public static string ObjectToJson2(object value)
        {
            return ObjectToJson2(value, false);
        }

        /// <summary>
        ///     序列化数据为Json数据格式.
        /// </summary>
        /// <param name="value">被序列化的对象</param>
        /// <param name="clearLastZero">是否清除小数位后的0</param>
        /// <returns></returns>
        public static string ObjectToJson2(object value, bool clearLastZero)
        {
            var type = value.GetType();
            var json = new JsonSerializer();
            //json.NullValueHandling = NullValueHandling.Ignore;
            json.ObjectCreationHandling = ObjectCreationHandling.Replace;
            json.MissingMemberHandling = MissingMemberHandling.Ignore;
            json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            json.Converters.Add(new StringEnumConverter());
            var timeFormate = new IsoDateTimeConverter();
            timeFormate.DateTimeFormat = "yyyy-MM-dd";
            json.Converters.Add(timeFormate);
            json.Formatting = Formatting.Indented;
            json.NullValueHandling = NullValueHandling.Ignore;

            if (clearLastZero)
                json.Converters.Add(new MinifiedNumArrayConverter());
            var sw = new StringWriter();
            var writer = new JsonTextWriter(sw);
            writer.Formatting = Formatting.None;
            writer.QuoteChar = '"';
            writer.QuoteName = false;
            json.Serialize(writer, value);

            var output = sw.ToString();
            writer.Close();
            sw.Close();

            return output;
        }

        /// <summary>
        ///     将Json数据转为对象
        /// </summary>
        /// <typeparam name="T">目标对象</typeparam>
        /// <param name="jsonText">json数据字符串</param>
        /// <returns></returns>
        public static T JsonToObject2<T>(string jsonText)
        {
            var json = new JsonSerializer();

            json.NullValueHandling = NullValueHandling.Ignore;
            json.ObjectCreationHandling = ObjectCreationHandling.Replace;
            json.MissingMemberHandling = MissingMemberHandling.Ignore;
            json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            var sr = new StringReader(jsonText);
            var reader = new JsonTextReader(sr);
            T result = default;
            try
            {
                result = (T) json.Deserialize(reader, typeof(T));
            }
            catch
            {
            }
            finally
            {
                reader.Close();
            }

            return result;
        }

        /// <summary>
        ///     普通集合转换Json
        /// </summary>
        /// <param name="array">集合对象</param>
        /// <returns>Json字符串</returns>
        public static string ListToJson(IEnumerable array)
        {
            var jsonString = "[";

            foreach (var item in array) jsonString += ObjectToJson(item) + ",";
            var t = jsonString.LastIndexOf(',');
            var strTmp = jsonString.Substring(0, t);
            return strTmp + "]";
        }


        /// <summary>
        ///     DataTable to json
        /// </summary>
        /// <param name="jsonName">返回json的名称</param>
        /// <param name="dt">转换成json的表</param>
        /// <returns></returns>
        public string DataTableToJson(string jsonName, DataTable dt, string strTotal = "")
        {
            var Json = new StringBuilder();
            Json.Append("[{\"TotalCount\":\"" + strTotal + "\",\"Head\":[");
            for (var i = 0; i < dt.Columns.Count; i++)
            {
                Json.Append("{\"ColumnHead\":\"" + dt + dt.Columns[i].ColumnName + "\"}");

                if (i < dt.Columns.Count - 1) Json.Append(",");
            }

            Json.Append("],");

            Json.Append("\"" + jsonName + "\":[");
            if (dt.Rows.Count > 0)
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (var j = 0; j < dt.Columns.Count; j++)
                    {
                        Json.Append("\"" + dt.Columns[j].ColumnName + "\":\"" + dt.Rows[i][j] + "\"");
                        if (j < dt.Columns.Count - 1) Json.Append(",");
                    }

                    Json.Append("}");
                    if (i < dt.Rows.Count - 1) Json.Append(",");
                }

            Json.Append("]}]");
            return Json.ToString();
        }


        public class MinifiedNumArrayConverter : JsonConverter
        {
            private readonly Type dblArrayType = typeof(double[]);
            private readonly Type decArrayType = typeof(decimal[]);
            private readonly Type decNullType = typeof(decimal?);
            private readonly Type decType = typeof(decimal);

            public override bool CanRead => false;

            private void dumpNumArray<T>(JsonWriter writer, T[] array)
            {
                foreach (var n in array)
                {
                    var s = n.ToString();
                    //此處可考慮改用string.format("{0:#0.####}")[小數後方#數目依最大小數位數決定]
                    //感謝網友vencin提供建議
                    if (s.EndsWith(".0"))
                        writer.WriteRawValue(s.Substring(0, s.Length - 2));
                    else if (s.Contains("."))
                        writer.WriteRawValue(s.TrimEnd('0'));
                    else
                        writer.WriteRawValue(s);
                }
            }

            private void dumpNum<T>(JsonWriter writer, T value)
            {
                var s = value.ToString();
                //此處可考慮改用string.format("{0:#0.####}")[小數後方#數目依最大小數位數決定]
                //感謝網友vencin提供建議
                if (s.EndsWith(".0"))
                    writer.WriteRawValue(s.Substring(0, s.Length - 2));
                else if (s.Contains("."))
                    writer.WriteRawValue(s.TrimEnd('0'));
                else
                    writer.WriteRawValue(s);
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var t = value.GetType();
                if (t == dblArrayType)
                {
                    writer.WriteStartArray();
                    dumpNumArray(writer, (double[]) value);
                    writer.WriteEndArray();
                }
                else if (t == decArrayType)
                {
                    writer.WriteStartArray();
                    dumpNumArray(writer, (decimal[]) value);
                    writer.WriteEndArray();
                }
                else if (t == decType || t == decNullType)
                {
                    dumpNum(writer, (decimal) value);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            public override bool CanConvert(Type objectType)
            {
                if (objectType == dblArrayType || objectType == decArrayType || objectType == decType ||
                    objectType == decNullType)
                    return true;
                return false;
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    }
}