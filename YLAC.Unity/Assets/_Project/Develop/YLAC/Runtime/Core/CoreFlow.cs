using CompanyName.UEPT.Runtime.Bootstrap.Units;
using CompanyName.UEPT.Runtime.Utilities;
using CompanyName.UEPT.Runtime.Utilities.Logging;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace CompanyName.UEPT.Runtime.Core
{
    public class CoreFlow : IStartable
    {
        private readonly LoadingService _loadingService;
        private readonly SceneManager _sceneManager;

        public CoreFlow(LoadingService loadingService, SceneManager sceneManager)
        {
            _loadingService = loadingService;
            _sceneManager = sceneManager;
        }

        public async void Start()
        {
            var fooLoadingUnit = new FooLoadingUnit(3, false);
            await _loadingService.BeginLoading(fooLoadingUnit);

            if (!fooLoadingUnit.IsLoaded)
                Log.Default.ThrowException("The end of example! Thank you for using this template!");

            _sceneManager.LoadScene(RuntimeConstants.Scenes.Bootstrap).Forget();
        }
    }
}