using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELib.Utilities
{
    public static class StringExtensions
    {
        //Phương thức kiểm tra chuỗi null, rỗng hay chỉ chứa khoảng trắng
        public static bool IsNullOrEmpty(this string source)
        {
            return source == null || source.Trim() == "";
        }
        //Phương thức cắt bớt các kí tự trong chuỗi
        public static string Truncate(this string source, int maxLength)
        {
            if (string.IsNullOrEmpty(source)) return source;
            return source.Length <= maxLength
                ? source
                : source.Substring(0, maxLength);
        }
        //Phương thức kiểm tra chuỗi text có chứa một chuỗi nào đó trong value hay không?
        public static bool ContainsAny(this string text, params string[] values)
        {
            if (text == null) return false;
            return values.Any(text.Contains);
        }

    }
}
