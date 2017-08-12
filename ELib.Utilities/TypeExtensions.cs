using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELib.Utilities
{
    public static class TypeExtensions
    {
        public static T To<T>(this object source)
        {
            return source.To<T>(default(T));
        }
        public static T To<T> (this object source, T defaultValue)
        {
            try
            {
                //Lấy kiểu dữ liệu T
                Type t = typeof(T);
                //Lấy kiểu dữ liệu T? (nullable)
                Type u = Nullable.GetUnderlyingType(t);
                if(u != null)
                {
                    //Nếu source == null hoặc chuỗi rỗng thì trả về default value
                    if (source == null || string.IsNullOrEmpty(source.ToString()))
                        return defaultValue;
                    //Ngược lại, ép kiểu sang kiểu T?
                    return (T)Convert.ChangeType(source.ToString(), u);
                }else {
                    //Ép kiểu sang kiểu T
                    return (T)Convert.ChangeType(source.ToString(), t);
                }   

            }
            catch
            {
                //Nếu có lỗi xảy ra trả về default value
                return defaultValue;
            }
        }
    }
}
