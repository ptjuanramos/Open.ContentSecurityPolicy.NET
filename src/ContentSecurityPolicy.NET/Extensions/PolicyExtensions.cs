using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ContentSecurityPolicy.NET.Extensions
{
    internal static class PolicyExtensions
    {
        public static string GetPreffix(this Policy policy)
        {
            Type type = policy.GetType();

            string name = Enum.GetName(type, policy);

            MemberInfo member = type.GetMembers()
                .FirstOrDefault(w => w.Name == name);

            DescriptionAttribute attribute = member != null
                ? member.GetCustomAttributes(true)
                    .FirstOrDefault(w => w.GetType() == typeof(DescriptionAttribute))
                        as DescriptionAttribute
                : null;

            return attribute != null ? attribute.Description : name;
        }
    }
}
