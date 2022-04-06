using System.Runtime.CompilerServices;

namespace Domain.Common
{
    public class CallerMember
    {
        public static string GetNameMethod([CallerMemberName] string caller = null) => caller;
        public static string GetClassName(dynamic model) => model.GetType().ToString();
    }
}
