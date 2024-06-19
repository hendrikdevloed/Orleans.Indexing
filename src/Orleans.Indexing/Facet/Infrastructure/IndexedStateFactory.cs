using Microsoft.Extensions.DependencyInjection;
using Orleans.Runtime;

namespace Orleans.Indexing.Facet
{
    public class IndexedStateFactory : IIndexedStateFactory
    {
        private readonly IGrainContext context;

        public IndexedStateFactory(IGrainContext context, IGrainFactory grainFactory)
            => this.context = context;

        public INonFaultTolerantWorkflowIndexedState<TState> CreateNonFaultTolerantWorkflowIndexedState<TState>(IIndexedStateConfiguration config)
            where TState : class, new()
            => this.CreateIndexedState<NonFaultTolerantWorkflowIndexedState<TState, IndexedGrainStateWrapper<TState>>>(config);

        public IFaultTolerantWorkflowIndexedState<TState> CreateFaultTolerantWorkflowIndexedState<TState>(IIndexedStateConfiguration config)
            where TState : class, new()
            => this.CreateIndexedState<FaultTolerantWorkflowIndexedState<TState>>(config);

        public ITransactionalIndexedState<TState> CreateTransactionalIndexedState<TState>(IIndexedStateConfiguration config)
            where TState : class, new()
            => this.CreateIndexedState<TransactionalIndexedState<TState>>(config);

        private TWrappedIndexedStateImplementation CreateIndexedState<TWrappedIndexedStateImplementation>(IIndexedStateConfiguration config)
            where TWrappedIndexedStateImplementation : ILifecycleParticipant<IGrainLifecycle>
        {
            var indexedState = ActivatorUtilities.CreateInstance<TWrappedIndexedStateImplementation>(this.context.ActivationServices, config);
            indexedState.Participate(context.ObservableLifecycle);
            return indexedState;
        }
    }
}
