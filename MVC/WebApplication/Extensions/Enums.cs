using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebApplication.Extensions
{
    public static class EnumsExtensions
    {
        public static string GetDisplayName(this Enum enu)
        {
            if (enu == null)
                return string.Empty;

            var enumType = enu.GetType();
            var field = enumType.GetField(enu.ToString());

            if (field == null)
                return string.Empty;

            return field.GetCustomAttribute<DisplayAttribute>().GetName();
        }
    }
}