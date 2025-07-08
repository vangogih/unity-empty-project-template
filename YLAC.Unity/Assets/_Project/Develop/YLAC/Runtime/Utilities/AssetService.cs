using UnityEngine;

namespace CompanyName.UEPT.Runtime.Utilities
{
    public static class AssetService
    {
        public static Resources R { get; } = new();
    }

    public sealed class Resources
    {
        public T Load<T>(string path) where T : Object
        {
            var result = UnityEngine.Resources.Load<T>(path);
            return result;
        }
    }
}