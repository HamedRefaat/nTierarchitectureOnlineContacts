using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineContacts.shared.Helper
{
   public static class EnumExtentions
    {
        private static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
            where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }

        public static string GetDisply(this Enum enumValue)
        {
            return enumValue.GetAttribute<DisplayAttribute>()?.Name;
        }

    }
}
