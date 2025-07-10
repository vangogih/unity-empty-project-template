using VContainer;
using VContainer.Unity;
using YLAC.Runtime.Utilities;

namespace YLAC.Runtime.Bootstrap
{
    public sealed class BootstrapScope : LifetimeScope
    {
        protected override void Awake()
        {
            IsRoot = true;
            DontDestroyOnLoad(this);
            base.Awake();
        }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<LoadingService>(Lifetime.Scoped);
            builder.Register<SceneManager>(Lifetime.Singleton);
            
            builder.RegisterEntryPoint<BootstrapFlow>();
        }
    }
}