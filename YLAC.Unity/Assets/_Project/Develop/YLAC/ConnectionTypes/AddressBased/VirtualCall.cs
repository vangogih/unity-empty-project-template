using VContainer;
using VContainer.Unity;

namespace YLAC.ConnectionTypes.AddressBased
{
    public class VirtualCallScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<Feature.One>(Lifetime.Singleton);
            builder.Register<Feature.Two>(Lifetime.Singleton);

            builder.RegisterEntryPoint<VirtualCallFlow>();
        }
    }
    public class VirtualCallFlow : IStartable
    {
        private Feature.One _one;
        private Feature.Two _two;

        public VirtualCallFlow(Feature.One one, Feature.Two two)
        {
            _one = one;
            _two = two;
        }
        public void Start()
        {
            _two.Do();
        }
    }

    public class VirtualCall
    {
        
    }
}