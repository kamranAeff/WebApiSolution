using Lesson01.Binders;
using System.ComponentModel;

namespace Lesson01.Models
{
    [TypeConverter(typeof(ColorTypeConverter))]
    public class Color
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
    }
}