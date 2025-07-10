using Cysharp.Threading.Tasks;
using YLAC.Runtime.Utilities;
using YLAC.Runtime.Utilities.Logging;

namespace YLAC.Runtime.Bootstrap.Units
{
    public sealed class FooLoadingUnit : ILoadUnit
    {
        public bool IsLoaded { get; private set; }

        private float _delay;
        private readonly bool _isLoadedWhenEnd;

        public FooLoadingUnit(float delay = 0f, bool isLoadedWhenEnd = true)
        {
            _delay = delay;
            _isLoadedWhenEnd = isLoadedWhenEnd;
        }

        public async UniTask Load()
        {
            Log.Loading.D($"foo is loading ... {(_delay > 0 ? _delay : string.Empty)}");

            while (_delay-- > 0)
            {
                await UniTask.Delay(1000);
                Log.Loading.D($"foo is loading ... {_delay}");
            }

            await UniTask.NextFrame();

            IsLoaded = _isLoadedWhenEnd;
        }
    }
}