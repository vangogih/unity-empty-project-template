using System.Threading;
using CompanyName.UEPT.Runtime.Bootstrap.Units;
using CompanyName.UEPT.Runtime.Utilities;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace CompanyName.UEPT.Runtime.Bootstrap
{
    public class BootstrapFlow : IAsyncStartable
    {
        private readonly LoadingService _loadingService;
        private readonly SceneManager _sceneManager;

        public BootstrapFlow(LoadingService loadingService, SceneManager sceneManager)
        {
            _loadingService = loadingService;
            _sceneManager = sceneManager;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            var fooLoadingUnit = new FooLoadingUnit();
            await _loadingService.BeginLoading(fooLoadingUnit);

            _sceneManager.LoadScene(RuntimeConstants.Scenes.Loading).Forget();
        }
    }
}
