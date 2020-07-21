
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;

namespace Application.BLLs.Base
{
    public abstract class BaseBll<TBll>
    {
        protected ConcurrentDictionary<Type, object> ServiceInstances => new ConcurrentDictionary<Type, object>();

        protected IServiceProvider ServiceProvider { get; }

        protected ILogger Logger
            => (ILogger<TBll>)ServiceInstances.GetOrAdd(typeof(ILogger<TBll>), ServiceProvider.GetService<ILogger<TBll>>());
        
        public BaseBll(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public BaseBll()
        {
        }
    }
}
