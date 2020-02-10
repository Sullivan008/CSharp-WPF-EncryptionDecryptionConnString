using System.Windows;

namespace EncryptionDecryptionConnString.Dialogs
{
    public class NotificationDialog
    {
        private readonly string _content;
        private readonly string _title;

        public NotificationDialog(string content, string title)
        {
            _content = content;
            _title = title;
        }

        public MessageBoxResult ShowErrorMessageBox() =>
            MessageBox.Show(_content, _title, MessageBoxButton.OK, MessageBoxImage.Error);

        public MessageBoxResult ShowInfoMessageBox() =>
            MessageBox.Show(_content, _title, MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
