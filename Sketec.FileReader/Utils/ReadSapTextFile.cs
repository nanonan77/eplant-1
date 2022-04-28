using System;
using System.Collections.Generic;
using System.IO;

namespace Sketec.FileReader.Utils
{
    public sealed partial class FileReaderUtils
    {
        public static IEnumerable<T> ReadSapTextFile<T>(Stream stream, int start = 1) where T : class, new()
        {
            var rows = new List<T>();
            using (var reader = new StreamReader(stream))
            {
                var line = String.Empty;
                var no = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    no++;
                    if (no == start) continue;

                    var row = new T();
                    MapTextFileToPropertyOrderingByColumnsAsString(row, line.Split("|,|"));
                    rows.Add(row);
                }
            }

            return rows;
        }
    }
}