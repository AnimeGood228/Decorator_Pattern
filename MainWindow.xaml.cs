using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Decorator_Pattern
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageTextBox.Text;
            INotifier notifier = null;

            // Создаем базовый EmailNotifier
            if (EmailCheckBox.IsChecked == true)
            {
                notifier = new EmailNotifier();
            }

            // Добавляем SMSNotifier, если выбран
            if (SmsCheckBox.IsChecked == true)
            {
                notifier = notifier == null ? new SmsNotifier(new EmailNotifier()) : new SmsNotifier(notifier);
            }

            // Добавляем FacebookNotifier, если выбран
            if (FacebookCheckBox.IsChecked == true)
            {
                notifier = notifier == null ? new FacebookNotifier(new EmailNotifier()) : new FacebookNotifier(notifier);
            }

            // Отправляем сообщение
            if (notifier != null)
            {
                notifier.Send(message);
                MessageBox.Show("Сообщение отправлено!");
            }
            else
            {
                MessageBox.Show("Выберите хотя бы один метод уведомления.");
            }
        }

        private void MessageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MessageTextBox.Text))
            {
                PlaceholderTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                PlaceholderTextBlock.Visibility = Visibility.Collapsed;
            }
        }
    }
}
