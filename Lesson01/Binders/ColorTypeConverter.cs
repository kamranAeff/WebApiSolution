using Lesson01.Models;
using Lesson01.Utils;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Lesson01.Binders
{
    /// <summary>
    /// TypeConverter bizə simple tipləri complex tiplərə çevirmək imkanı verir
    /// Yəni string olaraq gələn 123,12,13 tipli RGB dəyərini ColorType-a çevirməyi bu üsulla yerinə yetirəcəyik.
    /// </summary>
    public class ColorTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType==typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                var parameters = value.ToString().Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                byte red = 0, green = 0, blue = 0;

                if (Byte.TryParse(parameters.Get(0), out red) && Byte.TryParse(parameters.Get(1), out green) && Byte.TryParse(parameters.Get(2), out blue))
                    return new Color { Red = red, Blue = blue, Green = green };
            }

            if (context != null)
                return base.ConvertFrom(context, culture, value);
            else
                return null;

        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (typeof(string) == destinationType)
            {
                var color = (Color)value;
                return $"{color.Red},{color.Green},{color.Blue}";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}