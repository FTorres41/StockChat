using System;
using System.ComponentModel;
using System.Linq;

namespace StockChat.Domain.Enums
{
    public static class EnumHelper
    {
        public static string GetDescription(Enum enumerator)
        { 
            try
            {
                var enumType = typeof(Enum);
                var memberInfos = enumType.GetMember(enumerator.ToString());
                var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return ((DescriptionAttribute)valueAttributes[0]).Description;
            }
            catch
            {
                return null;
            }
        }
    }
}
