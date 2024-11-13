using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern
{
    public class FacebookNotifier : INotifier
    {
        private readonly INotifier _notifier;

        public FacebookNotifier(INotifier notifier)
        {
            _notifier = notifier;
        }

        public void Send(string message)
        {
            // Логика отправки сообщения в Facebook
            System.Diagnostics.Debug.WriteLine("Отправка Facebook сообщения: " + message);
            _notifier.Send(message);
        }
    }
}
