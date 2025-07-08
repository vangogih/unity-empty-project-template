using System.Threading.Tasks;
using VContainer;
using VContainer.Unity;

namespace YLAC.ConnectionTypes
{
    public class Feature
    {
        public class One
        {
            public Task Do() => Task.CompletedTask;
        }

        public class Two
        {
            public Task Do() => Task.CompletedTask;
        }
    }

    public class EventMediatorScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.Register<Feature.One>(Lifetime.Singleton);
            builder.Register<Feature.Two>(Lifetime.Singleton);

            builder.RegisterEntryPoint<EventMediatorFlow>();
        }
    }
    public class EventMediatorFlow : IStartable
    {
        private Feature.One _one;
        private Feature.Two _two;

        public EventMediatorFlow(Feature.One one, Feature.Two two)
        {
            _one = one;
            _two = two;
        }
        public async void Start()
        {
            // -1 - before one do
            await _one.Do();
            // 0 - after one do
            await _two.Do();
            // 1 - after two do
        }
        
        // EventMediator (Add, Start), State (Workload), Continuation (MoveNext), Awaiter (YieldInstruction)
    }
}