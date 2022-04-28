using System;
using Sketec.Core.Interfaces;

namespace Sketec.FileWriter.Textfile
{
    public static class TextFileHelper
    {
        public static string AppendTextFromClass(ITextModel model, string concat = "|,", string removeAtEnd = "|")
        {
            var text = "";

            foreach (var propName in model.PropertyList)
            {
                System.Reflection.PropertyInfo pi = model.GetType().GetProperty(propName);
                text += $"|{(String)pi.GetValue(model, null) ?? ""}";
                text += concat;
            }

            if (!string.IsNullOrWhiteSpace(removeAtEnd))
            {
                text = ReplaceLastOccurrence(text, concat, removeAtEnd);
            }

            return text;
        }

        public static string ReplaceLastOccurrence(string Source, string Find, string Replace)
        {
            int place = Source.LastIndexOf(Find);

            if (place == -1)
                return Source;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
        }
    }
}