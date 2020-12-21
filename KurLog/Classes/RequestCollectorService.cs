using System;
using System.Threading;
using System.Threading.Tasks;

namespace KurLog.Classes
{
    public class RequestCollectorService : HostedService
    {
        private readonly IGetDoviz _getDoviz;
        public RequestCollectorService(IGetDoviz getDoviz)
        {
            _getDoviz = getDoviz;
        }
        protected override async Task ExecuteAsync(CancellationToken cToken)
        {
            while (!cToken.IsCancellationRequested)
            {
                _getDoviz.dovizGet();
                await Task.Delay(TimeSpan.FromSeconds(10), cToken);
            }
        }
    }
}
