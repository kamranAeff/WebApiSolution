using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Lesson01.Utils
{
    public static partial class Extensions
    {
        static string[] formats = new[]{
                    "dd.MM.yyyy HH:mm:ss" ,
                    "dd.MM.yyyy HH:mm" ,
                    "dd.MM.yyyy",
                    "yyyy.MM.dd",
                    "yyyyMMddTHHmmss",
                    "yyyyMMddTHHmm",
                    "yyyyMMddHHmmss",
                    "yyyyMMddHHmm",
                    "yyyyMMdd",
                    "yyyy-MM-dd-HH-mm-ss",
                    "yyyy-MM-dd-HH-mm"
                };


        public static DateTime? ExtractDateFromString(this string expression,[Optional] string customFormat)
        {
            if (string.IsNullOrWhiteSpace(customFormat))
                return Parse(expression,formats);

            return Parse(expression,new[]{ customFormat }); ;
        }

        static DateTime? Parse(string value, string[] format)
        {

            DateTime date;
            if (DateTime.TryParseExact(value,
                format
                , System.Threading.Thread.CurrentThread.CurrentCulture
                , DateTimeStyles.None, out date))
            {
                return date;
            }

            return null;
        }

        public static string DateToTextWithoutDay(this DateTime? datex)
        {
            if (datex == null) return "";
            DateTime date = datex ?? DateTime.Now;
            string str1 = "";

            #region Year analysis
            switch (date.Year % 10)
            {
                case 0:
                    {
                        switch (date.Year % 100)
                        {
                            case 70:
                            case 80:
                            case 50:
                            case 20:
                                str1 = string.Format("{0} {1}-ci il", str1, date.Year);
                                break;
                            case 90:
                            case 60:
                            case 40:
                                str1 = string.Format("{0} {1}-cı il", str1, date.Year);
                                break;
                            case 30:
                            case 10:
                                str1 = string.Format("{0} {1}-cu il", str1, date.Year);
                                break;
                            case 0:
                                if (date.Year % 1000 != 0)
                                    str1 = string.Format("{0} {1}-cü il", str1, date.Year);
                                else
                                    str1 = string.Format("{0} {1}-ci il", str1, date.Year);
                                break;
                        }
                        break;
                    }
                case 1:
                case 2:
                case 5:
                case 7:
                case 8:
                    str1 = string.Format("{0} {1}-ci il", str1, date.Year);
                    break;
                case 3:
                case 4:
                    str1 = string.Format("{0} {1}-cü il", str1, date.Year);
                    break;
                case 6:
                    str1 = string.Format("{0} {1}-cı il", str1, date.Year);
                    break;
                case 9:
                    str1 = string.Format("{0} {1}-cu il", str1, date.Year);
                    break;
            }
            #endregion

            str1 += " " + GetMonthName(date).ToLower();

            return str1;
        }
        public static string DateToText(this DateTime? datex)
        {
            if (datex == null) return "";
            DateTime date = datex ?? DateTime.Now;

            string str1 = string.Format("{0:00} {1}", date.Day, GetMonthName(date)).ToLower();

            #region Year analysis
            switch (date.Year % 10)
            {
                case 0:
                    {
                        switch (date.Year % 100)
                        {
                            case 70:
                            case 80:
                            case 50:
                            case 20:
                                str1 = string.Format("{0} {1}-ci il", str1, date.Year);
                                break;
                            case 90:
                            case 60:
                            case 40:
                                str1 = string.Format("{0} {1}-cı il", str1, date.Year);
                                break;
                            case 30:
                            case 10:
                                str1 = string.Format("{0} {1}-cu il", str1, date.Year);
                                break;
                            case 0:
                                if (date.Year % 1000 != 0)
                                    str1 = string.Format("{0} {1}-cü il", str1, date.Year);
                                else
                                    str1 = string.Format("{0} {1}-ci il", str1, date.Year);
                                break;
                        }
                        break;
                    }
                case 1:
                case 2:
                case 5:
                case 7:
                case 8:
                    str1 = string.Format("{0} {1}-ci il", str1, date.Year);
                    break;
                case 3:
                case 4:
                    str1 = string.Format("{0} {1}-cü il", str1, date.Year);
                    break;
                case 6:
                    str1 = string.Format("{0} {1}-cı il", str1, date.Year);
                    break;
                case 9:
                    str1 = string.Format("{0} {1}-cu il", str1, date.Year);
                    break;
            }
            #endregion
            return str1;
        }

        public static string GetMonthName(this DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                    return "Yanvar";
                case 2:
                    return "Fevral";
                case 3:
                    return "Mart";
                case 4:
                    return "Aprel";
                case 5:
                    return "May";
                case 6:
                    return "İyun";
                case 7:
                    return "İyul";
                case 8:
                    return "Avqust";
                case 9:
                    return "Sentyabr";
                case 10:
                    return "Oktyabr";
                case 11:
                    return "Noyabr";
                case 12:
                default:
                    return "Dekabr";
            }
        }
    }
}