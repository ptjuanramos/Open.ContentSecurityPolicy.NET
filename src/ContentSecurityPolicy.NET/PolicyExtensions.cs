using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ContentSecurityPolicy.NET
{
    public static class PolicyExtensions
    {
        public static string GetPreffix(this Policy policy)
        {
            Type type = policy.GetType();

            string name = Enum.GetName(type, policy);

            MemberInfo member = type.GetMembers()
                .Where(w => w.Name == name)
                .FirstOrDefault();

            DescriptionAttribute attribute = member != null
                ? member.GetCustomAttributes(true)
                    .Where(w => w.GetType() == typeof(DescriptionAttribute))
                    .FirstOrDefault() as DescriptionAttribute
                : null;

            return attribute != null ? attribute.Description : name;
        }
    }
}
