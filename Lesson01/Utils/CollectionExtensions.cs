namespace Lesson01.Utils
{
    public static partial class Extensions
    {
        static public string Get(this string[] array,int index)
        {
            if (index >= array.Length)
                return string.Empty;

            return array[index];
        }

        static public int Get(this int[] array, int index)
        {
            if (index >= array.Length)
                return default(int);

            return array[index];
        }
    }
}