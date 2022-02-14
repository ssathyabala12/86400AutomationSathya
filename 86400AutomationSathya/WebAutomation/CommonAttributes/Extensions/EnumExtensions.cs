using System;
using System.ComponentModel;
using System.Reflection;

namespace _86400AutomationSathya.WebAutomation.CommonAttributes.Extensions
{
    public static class EnumExtensions
        {
            public static string GetDescription(this Enum e)
            {
                Type type = e.GetType();
                string name = Enum.GetName(type, e);
                if (name != null)
                {
                    FieldInfo field = type.GetField(name);
                    if (field != null)
                    {
                        var attr =
                               System.Attribute.GetCustomAttribute(field,
                                 typeof(DescriptionAttribute)) as DescriptionAttribute;
                        if (attr != null)
                        {
                            return attr.Description;
                        }
                    }
                }
                return null;
            }

            public static string GetValueAsString(this Enum e)
            {
                return e.ToString("D");
            }
        }
 }
