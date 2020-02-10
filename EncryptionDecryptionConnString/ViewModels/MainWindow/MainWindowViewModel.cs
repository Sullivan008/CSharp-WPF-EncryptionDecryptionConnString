using EncryptionDecryptionConnString.Command;
using EncryptionDecryptionConnString.Dialogs;
using EncryptionDecryptionConnString.Models;
using System;
using System.Linq;
using System.Windows.Input;

namespace EncryptionDecryptionConnString.ViewModels.MainWindow
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _name;

        private int? _amount;


        public MainWindowViewModel()
        {
            _name = string.Empty;
            _amount = null;
        }

        #region PROPERTIES Getters/ Setters

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public int? Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }

        #endregion

        #region COMMANDS

        public ICommand WindowLoaded =>
            new DelegateCommand(Loaded);

        #endregion

        #region PRIVATE COMMAND Helper Methods

        private void Loaded()
        {
            try
            {
                Client firstClient = GetFirstClient();

                Name = firstClient.Name;
                Amount = firstClient.Amount;

                new NotificationDialog("Successful Decrypt! The data is loaded into the Output Fields!", "Information")
                    .ShowInfoMessageBox();
            }
            catch (ArgumentNullException ex)
            {
                new NotificationDialog("First Client not found!\n\n" + ex, "Database error").ShowErrorMessageBox();
            }
            catch (Exception ex)
            {
                new NotificationDialog("Unsuccessful Decrypt!\n\n" + ex, "Error").ShowErrorMessageBox();
            }
        }

        #endregion

        #region PRIVATE Helper Methods

        private Client GetFirstClient()
        {
            using (ClientDBEntities db = new ClientDBEntities())
            {
                Client client = db.Clients.FirstOrDefault();

                if (client == null)
                {
                    throw new ArgumentNullException(nameof(client));
                }

                return client;
            }
        }

        #endregion
    }
}