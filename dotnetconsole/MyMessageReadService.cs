using Microsoft.Extensions.Logging;

namespace dotnetconsole
{
    public class MyMessageReadService : IMessageReadService
    {
        private readonly ILogger<MyMessageReadService> logger;

        public MyMessageReadService(ILogger<MyMessageReadService> logger)
        {
            this.logger = logger;
        }

        public string Read()
        {
            var msg = "Hello, world.";
            this.logger.LogInformation(msg);
            return msg;
        }
    }
}
