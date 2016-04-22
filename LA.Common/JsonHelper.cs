using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


//转换json字符串时间格式
namespace LA.Common
{
    public static class JsonHelper
    {
        public static string JsonDllSerializeSingle<T>(T t)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            return JsonConvert.SerializeObject(t, Formatting.Indented, timeFormat);
        }

        public static string JsonDllSerializeEntity<T>(T t)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            return JsonConvert.SerializeObject(t, Formatting.Indented, timeFormat);
        }
        public static string JsonDllSerializeEntity2<T>(T t)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy/MM/dd hh:mm:ss";
            return JsonConvert.SerializeObject(t, Formatting.Indented, timeFormat);
        }
        public static string JsonDllSerializeList<T>(List<T> tl)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            return JsonConvert.SerializeObject(tl, Formatting.Indented, timeFormat);
        }
        public static string JsonDllTableSerialize(DataTable dt)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            return JsonConvert.SerializeObject(dt, Formatting.Indented, timeFormat);
        }

        public static List<T> JsonDllDeserializeList<T>(string value)
        {
            return JsonConvert.DeserializeObject<List<T>>(value);
        }

        public static T JsonDllDeserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public static T JsonDllTableToObject<T>(DataTable dt)
        {
            string temp = JsonDllTableSerialize(dt);
            string value = temp.Substring(1, temp.Length - 2);
            T t = JsonConvert.DeserializeObject<T>(value);
            return t;
        }

        public static List<T> JsonDllTableToObjectList<T>(DataTable dt)
        {
            string temp = JsonDllTableSerialize(dt);
            List<T> tl = JsonConvert.DeserializeObject<List<T>>(temp);
            return tl;
        }
        

    }
}
