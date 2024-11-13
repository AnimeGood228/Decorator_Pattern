using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern
{
    public class SmsNotifier : INotifier
    {
        private readonly INotifier _notifier;

        public SmsNotifier(INotifier notifier)
        {
            _notifier = notifier;
        }

        public void Send(string message)
        {
            // Логика отправки SMS
            System.Diagnostics.Debug.WriteLine("Отправка SMS: " + message);
            _notifier.Send(message);
        }
    }
}
