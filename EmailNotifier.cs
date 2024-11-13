using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern
{
    public class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            // Логика отправки email
            System.Diagnostics.Debug.WriteLine("Отправка Email: " + message);
        }
    }
}
