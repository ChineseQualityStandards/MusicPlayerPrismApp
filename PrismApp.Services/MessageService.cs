
using PrismApp.Interfaces;

namespace PrismApp.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage() => "来自服务的问候。";
    }

}
