using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace YLAC.Runtime.Utilities
{
    public static class AssetService
    {
        public static Resources R { get; } = new();
        public static Addressables Add { get; } = new();
    }

    public sealed class Resources
    {
        public T Load<T>(string path) where T : Object
        {
            var result = UnityEngine.Resources.Load<T>(path);
            return result;
        }
    }

    public sealed class Addressables
    {
        private Dictionary<string, AsyncOperationHandle> _toRelease = new Dictionary<string, AsyncOperationHandle>();
        public UniTask<T> LoadAsync<T>(string key)
        {
            var op = UnityEngine.AddressableAssets.Addressables.LoadAssetAsync<T>(key);
            _toRelease.Add(key, op);
            var uniTask = op.ToUniTask();
            return uniTask;
        }

        public void Release(string key)
        {
            UnityEngine.AddressableAssets.Addressables.Release(_toRelease[key]);
        }
    }
}