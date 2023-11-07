using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Usuario.Domain.Enums
{
    public enum EnumEscolaridade
    {
        [Description("Infantil")]
        Infantil = 1,

        [Description("Fundamental")]
        Fundamental = 2,

        [Description("Médio")]
        Medio = 3,

        [Description("Superior")]
        Superior = 4
    }

    public static class EnumEscolaridadeExtensions
    {
        public static string GetDescription(this EnumEscolaridade value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
            }

            return value.ToString();
        }
    }
}
