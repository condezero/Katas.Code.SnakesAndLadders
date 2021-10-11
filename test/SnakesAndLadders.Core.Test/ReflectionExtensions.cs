using System.Reflection;

namespace SnakesAndLadders.Core.Test
{
    static class ReflectionExtensions
    {

        public static T GetPrivateField<T>(this object obj, string fieldName) where T : class
        {
            var field = obj.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

            return field?.GetValue(obj) as T;
        }
    }
}
