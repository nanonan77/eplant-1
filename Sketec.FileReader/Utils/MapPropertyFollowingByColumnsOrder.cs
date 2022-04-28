namespace Sketec.FileReader.Utils
{
    public sealed partial class FileReaderUtils
    {
        public static void MapTextFileToPropertyOrderingByColumnsAsString<T>(T obj, string[] columns) where T : class
        {
            var props = obj.GetType().GetProperties();

            var i = 0;
            foreach (var val in columns)
            {
                if (i >= props.Length)
                    break;
                var str = val;
                if (str.StartsWith('|'))
                {
                    if (str.Length > 1)
                        str = str.Substring(1);
                    else
                        str = "";
                }
                if (str.EndsWith('|'))
                {
                    if (str.Length == 1)
                        str = "";
                    else
                        str = str.Substring(0, str.Length - 1);
                }

                var prop = props[i++];
                prop.SetValue(obj, str.Trim());
            }
        }
    }
}
