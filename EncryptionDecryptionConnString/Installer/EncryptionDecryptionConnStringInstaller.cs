using EncryptionDecryptionConnString.Dialogs;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;

namespace EncryptionDecryptionConnString.Installer
{
    [RunInstaller(true)]
    public partial class EncryptionDecryptionConnStringInstaller : System.Configuration.Install.Installer
    {
        public EncryptionDecryptionConnStringInstaller()
        {
            InitializeComponent();
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);

            string provName = Context.Parameters["provName"];

            string exeFilePath = Context.Parameters["assemblypath"];

            ProtectSection(provName, exeFilePath);
        }

        #region PRIVATE Helper Methods

        /// <summary>
        ///     A paraméterben kiolvasott adatoknak megfelelően, a megfelelő szekció
        ///     titkosítása
        /// </summary>
        /// <param name="provName">A védelmet ellátó konfiguráció neve</param>
        /// <param name="exeFilePath">Az EXE elérési útvonala</param>
        private void ProtectSection(string provName, string exeFilePath)
        {
            ConnectionStringsSection configSection;

            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(exeFilePath);
                configSection = configuration.GetSection("connectionStrings") as ConnectionStringsSection;

                if (configSection != null)
                {
                    if (!configSection.ElementInformation.IsLocked && !configSection.SectionInformation.IsLocked)
                    {
                        if (!configSection.SectionInformation.IsProtected)
                        {
                            configSection.SectionInformation.ProtectSection(provName);
                        }

                        configSection.SectionInformation.ForceSave = true;

                        configuration.Save(ConfigurationSaveMode.Modified);

                        // A konfigurációs fájl megnyitása, hogy látható legyen, hogy a titkosítás sikeres volt! 
                        // Erre a szekcióra nincs szükség, csak a példa bemutatásáért maradt benne!
                        Process.Start("notepad.exe", configuration.FilePath);
                    }
                }
                else
                {
                    throw new ArgumentNullException(nameof(configSection));
                }
            }
            catch (ArgumentNullException ex)
            {
                switch (ex.ParamName)
                {
                    case nameof(configSection):
                        new NotificationDialog("Config Section not found!", "Error").ShowErrorMessageBox();
                        break;
                }
            }
            catch (Exception ex)
            {
                new NotificationDialog("Install error!\n\n" + ex, "Error").ShowErrorMessageBox();
            }
        }

        #endregion
    }
}
