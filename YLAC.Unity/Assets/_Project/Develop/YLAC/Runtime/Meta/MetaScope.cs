using VContainer;
using VContainer.Unity;

namespace CompanyName.UEPT.Runtime.Meta
{
    public sealed class MetaScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MetaFlow>();
        }
    }
}