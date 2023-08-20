using System.Threading;
using CompanyName.UEPT.Runtime.Bootstrap.Units;
using CompanyName.UEPT.Runtime.Utilities;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace CompanyName.UEPT.Runtime.Meta
{
    public class MetaFlow : IAsyncStartable
    {
        private readonly LoadingService _loadingService;
        private readonly SceneManager _sceneManager;

        public MetaFlow(LoadingService loadingService, SceneManager sceneManager)
        {
            _loadingService = loadingService;
            _sceneManager = sceneManager;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await _loadingService.BeginLoading(new FooLoadingUnit(3));
            _sceneManager.LoadScene(RuntimeConstants.Scenes.Core).Forget();
        }
    }
}