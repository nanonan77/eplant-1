using Sketec.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Sketec.Core.Extensions
{
    public static class EnumStringValueExtension
    {
        public static string GetStringValue(this Enum value)
        {
            if(value == null)
            {
                return null;
            }
            // Get the type
            var type = value.GetType();

            // Get fieldinfo for this type
            var fieldInfo = type.GetField(value.ToString());
            if (fieldInfo == null)
            {
                return null;
            }


            // Get the stringvalue attributes
            var attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Return the first if there was a match.
            if (attribs == null)
            {
                return null;
            }

            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }

        /// <summary>
        /// Parses the supplied enum and string value to find an associated enum value (case sensitive).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stringValue">String value.</param>
        /// <returns>
        /// Enum value associated with the string value, or null if not found.
        /// </returns>
        public static T SetStringValue<T>(string stringValue) where T : struct, IConvertible
        {
            return (T)SetStringValue(typeof(T), stringValue, false);
        }

        /// <summary>
        /// Parses the supplied enum and string value to find an associated enum value (case sensitive).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stringValue">The string value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static T SetStringValue<T>(string stringValue, T defaultValue) where T : struct, IConvertible
        {
            var enumValue = SetStringValue(typeof(T), stringValue, false) ?? defaultValue;
            return (T)enumValue;
        }

        /// <summary>
        /// Get all value from enum type
        /// </summary>
        /// <param name="type"></param>
        /// <returns>IList string</returns>
        public static IList<string> GetAllStringValue(Type type)
        {
            var result = new List<string>();

            if (!type.IsEnum)
            {
                throw new ArgumentException(string.Format("Supplied type must be an Enum.  Type was {0}", type));
            }

            foreach (var fieldInfo in type.GetFields())
            {
                //Check for our custom attribute
                var attrs = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

                if (attrs != null && attrs.Length > 0)
                {
                    result.Add(attrs[0].StringValue);
                }
            }

            return result;
        }

        /// <summary>
        /// Parses the supplied enum and string value to find an associated enum value.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="stringValue">String value.</param>
        /// <param name="ignoreCase">Denotes whether to conduct a case-insensitive match on the supplied string value</param>
        /// <returns>Enum value associated with the string value, or null if not found.</returns>
        private static object SetStringValue(Type type, string stringValue, bool ignoreCase)
        {
            object output = null;

            if (!type.IsEnum)
                throw new ArgumentException(string.Format("Supplied type must be an Enum.  Type was {0}", type));

            //Look for our string value associated with fields in this enum
            foreach (var fi in type.GetFields())
            {
                //Check for our custom attribute
                var attrs = fi.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

                string enumStringValue;
                if (attrs != null && attrs.Length > 0)
                {
                    enumStringValue = attrs[0].StringValue;
                }
                else
                {
                    enumStringValue = string.Empty;
                }


                if (!string.IsNullOrEmpty(stringValue))
                {
                    stringValue = stringValue.Trim();
                }

                //Check for equality then select actual enum value.
                if (string.Compare(enumStringValue, stringValue, ignoreCase) == 0)
                {
                    output = Enum.Parse(type, fi.Name);
                    break;
                }
            }

            return output;
        }

        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            var field = type.GetField(name);
            if (field != null)
            {
                var attr =
                        StringValueAttribute.GetCustomAttribute(field,
                            typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attr != null)
                {
                    return attr.Description;
                }
            }
            return null;
        }

        public static T GetEnumFromValue<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static T GetEnumFromDescription<T>(string description, string defaultValue = null)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = StringValueAttribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            if (!string.IsNullOrEmpty(defaultValue))
            {
                return GetEnumFromValue<T>(defaultValue);
            }
            throw new ArgumentException("Cannot found enum.", "description");
        }

        public static T GetEnumFromStringValue<T>(string stringValue, string defaultValue = null)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = StringValueAttribute.GetCustomAttribute(field,
                    typeof(StringValueAttribute)) as StringValueAttribute;
                if (attribute != null)
                {
                    if (attribute.StringValue == stringValue)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == stringValue)
                        return (T)field.GetValue(null);
                }
            }
            if (!string.IsNullOrEmpty(defaultValue))
            {
                return GetEnumFromValue<T>(defaultValue);
            }
            throw new ArgumentException("Cannot found enum.", stringValue);
        }
    }
}
