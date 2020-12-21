
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
namespace KurLog.Classes
{

    public abstract class HostedService : IHostedService, IDisposable
    {
        private Task currentTask;
        private CancellationTokenSource cancellationTokenSource;
        protected abstract Task ExecuteAsync(CancellationToken cToken);

        public virtual Task StartAsync(CancellationToken cancellationToken)
        {
            cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            
            currentTask = ExecuteAsync(cancellationTokenSource.Token);

            if (currentTask.IsCompleted)
                return currentTask;

            return Task.CompletedTask;
        }

        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            if (currentTask == null)
                return;

            try
            {
                cancellationTokenSource.Cancel();
            }
            finally
            {
                await Task.WhenAny(currentTask, Task.Delay(Timeout.Infinite, cancellationToken));
            }
        }
        public virtual void Dispose()
        {
            cancellationTokenSource.Cancel();
        }
    }
}
